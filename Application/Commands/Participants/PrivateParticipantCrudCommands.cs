using Application.Responses;
using Core.Enums;
using MediatR;

namespace Application.Commands.Participants {
    public class CreatePrivateParticipantCommand : IRequest<PrivateParticipantResponse> {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalCode { get; set; }
        public string AdditionalInfo { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
    }

    public class UpdatePrivateParticipantCommand : IRequest<Unit> {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalCode { get; set; }
        public string AdditionalInfo { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
    }
}
