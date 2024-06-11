using Application.Commands.Events;
using Application.Exceptions;
using Application.Responses;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using MediatR;
namespace Application.Handlers.Events {
    public class AddBusinessParticipantHandler : IRequestHandler<AddBusinessParticipantCommand, List<BusinessParticipantResponse>> {

        private readonly IEventRepository _eventRepository;
        private readonly IBusinessParticipantRepository _businessParticipantRepository;
        private readonly IEventBusinessParticipantRepository _eventBusinessParticipantRepository;
        private readonly IMapper _mapper;

        public AddBusinessParticipantHandler(
            IEventRepository eventRepository, 
            IBusinessParticipantRepository businessParticipantRepository, 
            IEventBusinessParticipantRepository eventBusinessParticipantRepository,
            IMapper mapper) {
            _eventRepository = eventRepository;
            _businessParticipantRepository = businessParticipantRepository;
            _eventBusinessParticipantRepository = eventBusinessParticipantRepository;
            _mapper = mapper;
        }

        public async Task<List<BusinessParticipantResponse>> Handle(AddBusinessParticipantCommand request, CancellationToken cancellationToken) {
            var dbEvent = await _eventRepository.Get(request.EventId);

            if (dbEvent == null) {
                throw new EntityNotFoundException(nameof(dbEvent), request.EventId);
            }

            var participant = await _businessParticipantRepository.Get(request.BusinessParticipantId);

            if (participant == null) {
                throw new EntityNotFoundException(nameof(participant), request.BusinessParticipantId);
            }

            var participantAlreadyAdded = await _eventBusinessParticipantRepository.Exists(request.EventId, request.BusinessParticipantId);

            if (!participantAlreadyAdded) {
                var eventParticipant = new EventBusinessParticipant();
                eventParticipant.Event = dbEvent;
                eventParticipant.BusinessParticipant = participant;
                _mapper.Map(participant, eventParticipant);
                await _eventBusinessParticipantRepository.Add(eventParticipant);
            }

            var eventParticipants = await _eventBusinessParticipantRepository.GetByEvent(request.EventId);
            var response = _mapper.Map<List<BusinessParticipantResponse>>(eventParticipants);
            return response;
        }
    }
}
