using Application.Responses;
using MediatR;

namespace Application.Queries.Events
{
    public class GetAllEventsQuery : IRequest<List<EventResponse>> {}
}
