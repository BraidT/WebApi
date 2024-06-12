using Core.Enums;

namespace Application.Responses {
    public class EventBusinessParticipantResponse {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public string RegistryCode { get; set; }
        public string AdditionalInfo { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public int? ParticipantCount { get; set; }
    }
}
