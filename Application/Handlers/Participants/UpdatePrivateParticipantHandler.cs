using Application.Commands.Participants;
using Application.Exceptions;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.Participants {
    public class UpdatePrivateParticipantHandler : IRequestHandler<UpdatePrivateParticipantCommand, Unit> {

        private readonly IPrivateParticipantRepository _privateParticipantRepository;
        private readonly IMapper _mapper;

        public UpdatePrivateParticipantHandler(IPrivateParticipantRepository privateParticipantRepository, IMapper mapper) {
            _privateParticipantRepository = privateParticipantRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePrivateParticipantCommand request, CancellationToken cancellationToken) {
            var participant = await _privateParticipantRepository.Get(request.Id);
            if (participant == null) {
                throw new EntityNotFoundException(nameof(participant), request.Id);
            }
            _mapper.Map(request, participant);
            await _privateParticipantRepository.Update(participant);
            return Unit.Value;
        }
    }
}
