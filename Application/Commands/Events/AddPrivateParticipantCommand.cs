using Application.Responses;
using MediatR;

namespace Application.Commands.Events
{
    public class AddPrivateParticipantCommand : IRequest<List<PrivateParticipantResponse>> {
        public int EventId { get; set; }
        public int PrivateParticipantId { get; set; }
    }
}
