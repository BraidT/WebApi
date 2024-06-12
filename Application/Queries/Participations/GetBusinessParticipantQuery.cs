using Application.Responses;
using MediatR;

namespace Application.Queries.Participations {
    public class GetBusinessParticipantQuery : IRequest<BusinessParticipantResponse>{
        public int ParticipantId { get; set; }

        public GetBusinessParticipantQuery(int participantId) {
            ParticipantId = participantId;
        }
    }
}
