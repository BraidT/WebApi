using Application.Commands.Participants;
using Application.Exceptions;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.EventParticipants {
    public class UpdateEventPrivateParticipantHandler : IRequestHandler<UpdateEventPrivateParticipantCommand, Unit> {

        private readonly IEventPrivateParticipantRepository _businessParticipantRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IPrivateParticipantRepository _participantRepository;
        private readonly IMapper _mapper;

        public UpdateEventPrivateParticipantHandler(IEventPrivateParticipantRepository businessParticipantRepository, IEventRepository eventRepository, IMapper mapper) {
            _businessParticipantRepository = businessParticipantRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventPrivateParticipantCommand request, CancellationToken cancellationToken) {
            var eventParticipant = await _businessParticipantRepository.Get(request.Id);
            if (eventParticipant == null) {
                throw new EntityNotFoundException(nameof(eventParticipant), request.Id);
            }

            var dbEvent = await _eventRepository.Get(request.EventId);
            if (dbEvent == null) {
                throw new EntityNotFoundException(nameof(dbEvent), request.Id);
            }

            var participant = await _eventRepository.Get(request.PrivateParticipantId);
            if (dbEvent == null) {
                throw new EntityNotFoundException(nameof(participant), request.Id);
            }

            _mapper.Map(request, participant);
            await _businessParticipantRepository.Update(eventParticipant);
            return Unit.Value;
        }
    }
}
