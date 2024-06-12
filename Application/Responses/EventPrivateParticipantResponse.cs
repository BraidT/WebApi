using Core.Enums;

namespace Application.Responses {
    public class EventPrivateParticipantResponse {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalCode { get; set; }
        public string AdditionalInfo { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
    }
}
