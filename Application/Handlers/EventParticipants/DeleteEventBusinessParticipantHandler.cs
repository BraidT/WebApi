using Application.Commands.Participants;
using Application.Exceptions;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.EventParticipants
{
    public class DeleteEventBusinessParticipantHandler : IRequestHandler<DeleteEventBusinessParticipantCommand, Unit> {

        private readonly IEventBusinessParticipantRepository _eventBusinessParticipantRepository;

        public DeleteEventBusinessParticipantHandler(IEventBusinessParticipantRepository eventBusinessParticipantRepository) {
            _eventBusinessParticipantRepository = eventBusinessParticipantRepository;
        }

        public async Task<Unit> Handle(DeleteEventBusinessParticipantCommand request, CancellationToken cancellationToken) {
            var eventBusinessParticipant = await _eventBusinessParticipantRepository.Get(request.EventBusinessParticipantId);
            if (eventBusinessParticipant == null) {
                throw new EntityNotFoundException(nameof(eventBusinessParticipant), request.EventBusinessParticipantId);
            }
            await _eventBusinessParticipantRepository.Delete(eventBusinessParticipant);
            return Unit.Value;
        }
    }
}
