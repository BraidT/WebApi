namespace Core.Entities {
    public class PrivateParticipant:EntityBase {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalCode { get; set; }
        public ICollection<EventPrivateParticipant> EventPrivateParticipants { get; set; }
    }
}
