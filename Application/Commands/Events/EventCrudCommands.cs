using Application.Responses;
using MediatR;

namespace Application.Commands.Events
{
    public class CreateEventCommand : IRequest<EventResponse>
    {
        public string Name { get; set; }
        public DateTime BeginTime { get; set; }
        public string Location { get; set; }
        public string AdditionalInfo { get; set; }
    }

    public class UpdateEventCommand : IRequest<Unit> {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime BeginTime { get; set; }
        public string Location { get; set; }
        public string AdditionalInfo { get; set; }
    }

    public class DeleteEventCommand : IRequest<Unit> {
        public int EventId { get; set; }

        public DeleteEventCommand(int eventId) {
            EventId = eventId;
        }
    }
}
