using MediatR;

namespace Application.Commands.Events {
    public class DeleteEventCommand : IRequest<Unit> {
        public int EventId { get; set; }
    }
}
