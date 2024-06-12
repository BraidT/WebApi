using Application.Commands.Participants;
using Application.Exceptions;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.EventParticipants {
    public class UpdateEventBusinessParticipantHandler : IRequestHandler<UpdateEventBusinessParticipantCommand, Unit> {

        private readonly IEventBusinessParticipantRepository _businessParticipantRepository;
        private readonly IMapper _mapper;

        public UpdateEventBusinessParticipantHandler(IEventBusinessParticipantRepository businessParticipantRepository, IMapper mapper) {
            _businessParticipantRepository = businessParticipantRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventBusinessParticipantCommand request, CancellationToken cancellationToken) {
            var eventParticipant = await _businessParticipantRepository.Get(request.Id);
            if (eventParticipant == null) {
                throw new EntityNotFoundException(nameof(eventParticipant), request.Id);
            }

            _mapper.Map(request, eventParticipant);
            await _businessParticipantRepository.Update(eventParticipant);
            return Unit.Value;
        }
    }
}
