using Application.Commands.Participants;
using Application.Exceptions;
using Application.Responses;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.EventParticipants {
    public class CreateEventPrivateParticipantHandler : IRequestHandler<CreateEventPrivateParticipantCommand, EventPrivateParticipantResponse> {

        private readonly IEventPrivateParticipantRepository _privateEventParticipantRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IPrivateParticipantRepository _participantRepository;
        private readonly IMapper _mapper;

        public CreateEventPrivateParticipantHandler(IEventPrivateParticipantRepository privateEventParticipantRepository, IEventRepository eventRepository, IPrivateParticipantRepository participantRepository, IMapper mapper) {
            _privateEventParticipantRepository = privateEventParticipantRepository;
            _eventRepository = eventRepository;
            _participantRepository = participantRepository;
            _mapper = mapper;
        }

        public async Task<EventPrivateParticipantResponse> Handle(CreateEventPrivateParticipantCommand request, CancellationToken cancellationToken) {
            var dbEvent = await _eventRepository.Get(request.EventId);
            if (dbEvent == null) {
                throw new EntityNotFoundException(nameof(dbEvent), request.EventId);
            }

            var participant = await _participantRepository.Get(request.PrivateParticipantId);
            if (participant == null) {
                throw new EntityNotFoundException(nameof(participant), request.PrivateParticipantId);
            }

            var eventParticipant = _mapper.Map<EventPrivateParticipant>(request);
            await _privateEventParticipantRepository.Add(eventParticipant);
            var participantResponse = _mapper.Map<EventPrivateParticipantResponse>(participant);
            return participantResponse;
        }
    }
}
