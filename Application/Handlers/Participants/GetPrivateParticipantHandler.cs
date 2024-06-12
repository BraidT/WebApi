using Application.Queries.Participations;
using Application.Responses;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.Participants {
    public class GetPrivateParticipantHandler : IRequestHandler<GetPrivateParticipantQuery, PrivateParticipantResponse> {

        private readonly IPrivateParticipantRepository _privateParticipantRepository;
        private readonly IMapper _mapper;

        public GetPrivateParticipantHandler(IPrivateParticipantRepository privateParticipantRepository, IMapper mapper) {
            _privateParticipantRepository = privateParticipantRepository;
            _mapper = mapper;
        }
        public async Task<PrivateParticipantResponse> Handle(GetPrivateParticipantQuery request, CancellationToken cancellationToken) {
            var participant = await _privateParticipantRepository.Get(request.ParticipantId);
            return _mapper.Map<PrivateParticipantResponse>(participant);
        }
    }
}
