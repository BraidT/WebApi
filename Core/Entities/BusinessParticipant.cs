using Core.Enums;

namespace Core.Entities {
    public class BusinessParticipant : EntityBase {
        public string Name { get; set; }
        public string RegistryCode { get; set; }
        public string AdditionalInfo { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public int? ParticipantCount { get; set; }
        public ICollection<EventBusinessParticipant> EventBusinessParticipants { get; set; }
    }
}
