using Application.Responses;
using Core.Enums;
using MediatR;

namespace Application.Commands.Participants {
    public class CreateBusinessParticipantCommand : IRequest<BusinessParticipantResponse> {
        public string Name { get; set; }
        public string RegistryCode { get; set; }
        public string AdditionalInfo { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public int? ParticipantCount { get; set; }
    }
}
