using Application.Commands.Participants;
using Application.Responses;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.Participants {
    public class CreateBusinessParticipantHandler : IRequestHandler<CreateBusinessParticipantCommand, BusinessParticipantResponse> {

        private readonly IBusinessParticipantRepository _businessParticipantRepository;
        private readonly IMapper _mapper;

        public CreateBusinessParticipantHandler(IBusinessParticipantRepository businessParticipantRepository, IMapper mapper) {
            _businessParticipantRepository = businessParticipantRepository;
            _mapper = mapper;
        }

        public async Task<BusinessParticipantResponse> Handle(CreateBusinessParticipantCommand request, CancellationToken cancellationToken) {
            var participant = _mapper.Map<BusinessParticipant>(request);
            await _businessParticipantRepository.Add(participant);
            var participantResponse = _mapper.Map<BusinessParticipantResponse>(participant);
            return participantResponse;
        }
    }
}
