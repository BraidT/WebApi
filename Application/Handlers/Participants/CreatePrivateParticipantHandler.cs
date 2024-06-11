using Application.Commands.Participants;
using Application.Responses;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.Participants {
    public class CreatePrivateParticipantHandler : IRequestHandler<CreatePrivateParticipantCommand, PrivateParticipantResponse> {

        private readonly IPrivateParticipantRepository _privateParticipantRepository;
        private readonly IMapper _mapper;

        public CreatePrivateParticipantHandler(IPrivateParticipantRepository privateParticipantRepository, IMapper mapper) {
            _privateParticipantRepository = privateParticipantRepository;
            _mapper = mapper;
        }

        public async Task<PrivateParticipantResponse> Handle(CreatePrivateParticipantCommand request, CancellationToken cancellationToken) {
            var participant = _mapper.Map<PrivateParticipant>(request);
            await _privateParticipantRepository.Add(participant);
            var participantResponse = _mapper.Map<PrivateParticipantResponse>(participant);
            return participantResponse;
        }
    }
}
