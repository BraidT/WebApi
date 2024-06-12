using Application.Responses;
using MediatR;

namespace Application.Queries.Participations {
    public class GetEventBusinessParticipantsQuery : IRequest<List<BusinessParticipantResponse>> {
        public int EventId { get; set; }

        public GetEventBusinessParticipantsQuery(int eventId) {
            EventId = eventId;
        }
    }
}
