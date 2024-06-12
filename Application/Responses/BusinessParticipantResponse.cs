using Core.Enums;

namespace Application.Responses {
    public class BusinessParticipantResponse {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegistryCode { get; set; }
        public string AdditionalInfo { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public int? ParticipantCount { get; set; }
    }
}
