using Core.Enums;

namespace Core.Entities {
    public class EventPrivateParticipant : EntityBase {
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int PrivateParticipantId { get; set; }
        public PrivateParticipant PrivateParticipant { get; set; }
        public string AdditionalInfo { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
    }
}
