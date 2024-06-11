using Application.Commands.Participants;
using Application.Exceptions;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.Participants {
    public class UpdateBusinessParticipantHandler : IRequestHandler<UpdateBusinessParticipantCommand, Unit> {

        private readonly IBusinessParticipantRepository _businessParticipantRepository;
        private readonly IMapper _mapper;

        public UpdateBusinessParticipantHandler(IBusinessParticipantRepository businessParticipantRepository, IMapper mapper) {
            _businessParticipantRepository = businessParticipantRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBusinessParticipantCommand request, CancellationToken cancellationToken) {
            var participant = await _businessParticipantRepository.Get(request.Id);
            if (participant == null) {
                throw new EntityNotFoundException(nameof(participant), request.Id);
            }
            _mapper.Map(request, participant);
            await _businessParticipantRepository.Update(participant);
            return Unit.Value;
        }
    }
}
