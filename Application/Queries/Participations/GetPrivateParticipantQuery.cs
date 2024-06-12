using Application.Responses;
using MediatR;

namespace Application.Queries.Participations {
    public class GetPrivateParticipantQuery : IRequest<PrivateParticipantResponse> {
        public int ParticipantId { get; set; }

        public GetPrivateParticipantQuery(int participantId) {
            ParticipantId = participantId;
        }
    }
}
