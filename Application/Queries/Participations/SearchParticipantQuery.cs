using Application.Responses;
using MediatR;

namespace Application.Queries.Participations {
    public class SearchParticipantsQuery : IRequest<ParticipantSearchResponse> {

        public string SearchTerm { get; }

        public SearchParticipantsQuery(string searchTerm) {
            SearchTerm = searchTerm;
        }
    }
}
