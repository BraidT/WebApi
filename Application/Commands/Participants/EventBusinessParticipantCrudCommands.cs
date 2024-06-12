using Application.Responses;
using Core.Enums;
using MediatR;

namespace Application.Commands.Participants {
    public class UpdateEventBusinessParticipantCommand : IRequest<Unit> {
        public int Id { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public string AdditionalInfo { get; set; }
        public int? ParticipantCount { get; set; }
    }

    public class CreateEventBusinessParticipantCommand : IRequest<EventBusinessParticipantResponse> {
        public int BusinessParticipantId { get; set; }
        public int EventId { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public string AdditionalInfo { get; set; }
        public int? ParticipantCount { get; set; }
    }

    public class DeleteEventBusinessParticipantCommand : IRequest<Unit> {
        public int EventBusinessParticipantId { get; set; }
        public DeleteEventBusinessParticipantCommand(int eventBusinessParticipantId) {
            this.EventBusinessParticipantId = eventBusinessParticipantId;
        }
    }
}
