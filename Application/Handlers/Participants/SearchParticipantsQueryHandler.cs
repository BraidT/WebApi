using Application.Queries.Participations;
using Application.Responses;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.Participants {
    public class SearchParticipantsQueryHandler : IRequestHandler<SearchParticipantsQuery, ParticipantSearchResponse> {
        private readonly IBusinessParticipantRepository _businessRepository;
        private readonly IPrivateParticipantRepository _privateRepository;
        private readonly IMapper _mapper;

        public SearchParticipantsQueryHandler(IBusinessParticipantRepository businessRepository, IPrivateParticipantRepository privateRepository, IMapper mapper) {
            _businessRepository = businessRepository;
            _privateRepository = privateRepository;
            _mapper = mapper;
        }

        public async Task<ParticipantSearchResponse> Handle(SearchParticipantsQuery request, CancellationToken cancellationToken) {
            var privateParticipants = await _privateRepository.GetAll(x => x.FirstName.Contains(request.SearchTerm) || x.LastName.Contains(request.SearchTerm) || x.PersonalCode.Contains(request.SearchTerm));
            var businessParticipants = await _businessRepository.GetAll(x => x.Name.Contains(request.SearchTerm) || x.RegistryCode.Contains(request.SearchTerm));

            var privateParticipantsResponse = _mapper.Map<List<PrivateParticipantResponse>>(privateParticipants);
            var businessParticipantsResponse = _mapper.Map<List<BusinessParticipantResponse>>(businessParticipants);
            
            return new ParticipantSearchResponse { PrivateParticipants = privateParticipantsResponse, BusinessParticipants = businessParticipantsResponse };
        }
    }
}
