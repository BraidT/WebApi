namespace Core.Entities {
    public class Event :EntityBase{
        public string Name { get; set; }
        public DateTime BeginTime { get; set; }
        public string Location { get; set; }
        public string AdditionalInfo { get; set; }
        public ICollection<EventPrivateParticipant> EventPrivateParticipants { get; set; }
        public ICollection<EventBusinessParticipant> EventBusinessParticipants { get; set; }
    }
}
