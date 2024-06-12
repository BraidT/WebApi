using Application.Commands.Participants;
using Application.Exceptions;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.EventParticipants
{
    public class DeleteEventPrivateParticipantHandler : IRequestHandler<DeleteEventPrivateParticipantCommand, Unit> {

        private readonly IEventPrivateParticipantRepository _eventPrivateParticipantRepository;

        public DeleteEventPrivateParticipantHandler(IEventPrivateParticipantRepository eventPrivateParticipantRepository) {
            _eventPrivateParticipantRepository = eventPrivateParticipantRepository;
        }

        public async Task<Unit> Handle(DeleteEventPrivateParticipantCommand request, CancellationToken cancellationToken) {
            var eventPrivateParticipant = await _eventPrivateParticipantRepository.Get(request.EventPrivateParticipantId);
            if (eventPrivateParticipant == null) {
                throw new EntityNotFoundException(nameof(eventPrivateParticipant), request.EventPrivateParticipantId);
            }
            await _eventPrivateParticipantRepository.Delete(eventPrivateParticipant);
            return Unit.Value;
        }
    }
}
