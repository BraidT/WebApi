using Application.Queries.Participations;
using Application.Responses;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.Participants {
    internal class GetBusinessParticipantHandler : IRequestHandler<GetBusinessParticipantQuery, BusinessParticipantResponse> {

        private readonly IBusinessParticipantRepository _businessParticipantRepository;
        private readonly IMapper _mapper;

        public GetBusinessParticipantHandler(IBusinessParticipantRepository businessParticipantRepository, IMapper mapper) {
            _businessParticipantRepository = businessParticipantRepository;
            _mapper = mapper;
        }
        public async Task<BusinessParticipantResponse> Handle(GetBusinessParticipantQuery request, CancellationToken cancellationToken) {
            var participant = await _businessParticipantRepository.Get(request.ParticipantId);
            return _mapper.Map<BusinessParticipantResponse>(participant);
        }
    }
}
