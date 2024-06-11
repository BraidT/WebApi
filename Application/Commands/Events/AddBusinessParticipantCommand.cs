using Application.Responses;
using MediatR;

namespace Application.Commands.Events
{
    public class AddBusinessParticipantCommand : IRequest<List<BusinessParticipantResponse>>
    {
        public int EventId { get; set; }
        public int BusinessParticipantId { get; set; }
    }
}
