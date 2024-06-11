using Application.Commands.Events;
using Application.Exceptions;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.Events {
    public class DeleteEventHandler : IRequestHandler<DeleteEventCommand, Unit> {

        private readonly IEventRepository _eventRepository;

        public DeleteEventHandler(IEventRepository eventRepository) {
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken) {
            var dbEvent = await _eventRepository.Get(request.EventId);
            if (dbEvent == null) {
                throw new EntityNotFoundException(nameof(dbEvent), request.EventId);
            }
            await _eventRepository.Delete(dbEvent);
            return Unit.Value;
        }
    }
}
