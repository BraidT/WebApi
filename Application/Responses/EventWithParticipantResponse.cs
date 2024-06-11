namespace Application.Responses {
    public class EventWithParticipantsResponse {
        public EventResponse Event { get; set; }
        public List<BusinessParticipantResponse> BusinessParticipants { get; set; }
        public List<PrivateParticipantResponse> PrivateParticipants { get; set; }
    }
}
