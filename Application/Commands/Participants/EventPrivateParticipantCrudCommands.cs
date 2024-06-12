using Application.Responses;
using Core.Enums;
using MediatR;

namespace Application.Commands.Participants {
    public class UpdateEventPrivateParticipantCommand : IRequest<Unit> {
        public int Id { get; set; }
        public int PrivateParticipantId { get; set; }
        public int EventId { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public string AdditionalInfo { get; set; }
        public int? ParticipantCount { get; set; }
    }

    public class CreateEventPrivateParticipantCommand : IRequest<EventPrivateParticipantResponse> {
        public int PrivateParticipantId { get; set; }
        public int EventId { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public string AdditionalInfo { get; set; }
        public int? ParticipantCount { get; set; }
    }

    public class DeleteEventPrivateParticipantCommand : IRequest<Unit> {
        public int EventPrivateParticipantId { get; set; }
        public DeleteEventPrivateParticipantCommand(int eventPrivateParticipantId) {
            this.EventPrivateParticipantId = eventPrivateParticipantId;
        }
    }
}
