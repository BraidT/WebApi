using Application.Responses;
using MediatR;

namespace Application.Queries.Participations {
    public class GetEventPrivateParticipantsQuery : IRequest<List<EventPrivateParticipantResponse>> {
        public int EventId {  get; set; }

        public GetEventPrivateParticipantsQuery(int eventId) {
            EventId = eventId;
        }
    }
}
