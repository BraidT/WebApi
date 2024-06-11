using Application.Commands.Events;
using Application.Exceptions;
using Application.Responses;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Handlers.Events {
    public class AddPrivateParticipantHandler : IRequestHandler<AddPrivateParticipantCommand, List<PrivateParticipantResponse>> {

        private readonly IEventRepository _eventRepository;
        private readonly IPrivateParticipantRepository _privateParticipantRepository;
        private readonly IEventPrivateParticipantRepository _eventPrivateParticipantRepository;
        private readonly IMapper _mapper;

        public AddPrivateParticipantHandler(
            IEventRepository eventRepository,
            IPrivateParticipantRepository privateParticipantRepository,
            IEventPrivateParticipantRepository eventPrivateParticipantRepository,
            IMapper mapper) {
            _eventRepository = eventRepository;
            _privateParticipantRepository = privateParticipantRepository;
            _eventPrivateParticipantRepository = eventPrivateParticipantRepository;
            _mapper = mapper;
        }

        public async Task<List<PrivateParticipantResponse>> Handle(AddPrivateParticipantCommand request, CancellationToken cancellationToken) {
            var dbEvent = await _eventRepository.Get(request.EventId);

            if (dbEvent == null) {
                throw new EntityNotFoundException(nameof(dbEvent), request.EventId);
            }

            var participant = await _privateParticipantRepository.Get(request.PrivateParticipantId);
          
            if (participant == null) {
                throw new EntityNotFoundException(nameof(participant), request.PrivateParticipantId);
            }

            var participantAlreadyAdded = await _eventPrivateParticipantRepository.Exists(request.EventId, request.PrivateParticipantId);

            if (!participantAlreadyAdded) {
                var eventParticipant = new EventPrivateParticipant();
                eventParticipant.Event = dbEvent;
                eventParticipant.PrivateParticipant = participant;
                _mapper.Map(participant, eventParticipant);
                await _eventPrivateParticipantRepository.Add(eventParticipant);
            }

            var eventParticipants = await _eventPrivateParticipantRepository.GetByEvent(request.EventId);
            return _mapper.Map<List<PrivateParticipantResponse>>(eventParticipants);
        }
    }
}
