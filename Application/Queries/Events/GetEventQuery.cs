using Application.Responses;
using MediatR;

namespace Application.Queries.Events {
    public class GetEventQuery : IRequest<EventResponse>{
        public int Id { get; set; }
    }
}
