using Core.Enums;

namespace Core.Entities {
    public class EventBusinessParticipant : EntityBase {
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int BusinessParticipantId { get; set; }
        public BusinessParticipant BusinessParticipant { get; set; }
        public string AdditionalInfo { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
    }
}
