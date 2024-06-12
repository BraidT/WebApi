using Application.Commands.Participants;
using Application.Exceptions;
using Application.Responses;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;
namespace Application.Handlers.EventParticipants {
    public class CreateEventBusinessParticipantHandler : IRequestHandler<CreateEventBusinessParticipantCommand, EventBusinessParticipantResponse> {

        private readonly IEventBusinessParticipantRepository _businessEventParticipantRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IBusinessParticipantRepository _participantRepository;
        private readonly IMapper _mapper;

        public CreateEventBusinessParticipantHandler(IEventBusinessParticipantRepository businessEventParticipantRepository, IBusinessParticipantRepository participantRepository, IEventRepository eventRepository, IMapper mapper) {
            _businessEventParticipantRepository = businessEventParticipantRepository;
            _participantRepository = participantRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<EventBusinessParticipantResponse> Handle(CreateEventBusinessParticipantCommand request, CancellationToken cancellationToken) {

            var participantAlreadyAdded = await _businessEventParticipantRepository.Exists(request.EventId, request.BusinessParticipantId);

            if (participantAlreadyAdded) {
                throw new BadRequestException("Participant already added");
            }

            var dbEvent = await _eventRepository.Get(request.EventId);
            if (dbEvent == null) {
                throw new EntityNotFoundException(nameof(dbEvent), request.EventId);
            }

            var participant = await _participantRepository.Get(request.BusinessParticipantId);
            if (participant == null) {
                throw new EntityNotFoundException(nameof(participant), request.BusinessParticipantId);
            }

            var eventParticipant = _mapper.Map<EventBusinessParticipant>(request);
            await _businessEventParticipantRepository.Add(eventParticipant);
            var participantResponse = _mapper.Map<EventBusinessParticipantResponse>(eventParticipant);
            return participantResponse;
        }
    }
}
