namespace Core.Entities {
    public class BusinessParticipant : EntityBase {
        public string Name { get; set; }
        public string RegistryCode { get; set; }
        public ICollection<EventBusinessParticipant> EventBusinessParticipants { get; set; }
    }
}
