using Application.Responses;
using MediatR;

namespace Application.Queries.Participations {
    public class GetEventPrivateParticipantsQuery : IRequest<List<PrivateParticipantResponse>> {
        public int EventId {  get; set; }

        public GetEventPrivateParticipantsQuery(int eventId) {
            EventId = eventId;
        }
    }
}
