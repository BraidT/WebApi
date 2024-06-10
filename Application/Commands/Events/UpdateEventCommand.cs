using MediatR;

namespace Application.Commands.Events {
    public class UpdateEventCommand : IRequest<Unit> {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime BeginTime { get; set; }
        public string Location { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
