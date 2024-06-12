
namespace Application.Responses {
    public class ParticipantSearchResponse {
        public List<PrivateParticipantResponse> PrivateParticipants { get; set; }
        public List<BusinessParticipantResponse> BusinessParticipants { get; set; }
    }
}
