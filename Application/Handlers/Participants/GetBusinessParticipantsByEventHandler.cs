using Application.Queries.Participations;
using Application.Responses;
using AutoMapper;
using Core.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Handlers.Participants {
    public class GetBusinessParticipantsByEventHandler : IRequestHandler<GetEventBusinessParticipantsQuery, List<BusinessParticipantResponse>> {

        private readonly IEventBusinessParticipantRepository _eventBusinessParticipantRepository;
        private readonly IMapper _mapper;

        public GetBusinessParticipantsByEventHandler(IEventBusinessParticipantRepository eventBusinessParticipantRepository, IMapper mapper) {
            _eventBusinessParticipantRepository = eventBusinessParticipantRepository;
            _mapper = mapper;
        }
        public async Task<List<BusinessParticipantResponse>> Handle(GetEventBusinessParticipantsQuery request, CancellationToken cancellationToken) {
            var participants = await _eventBusinessParticipantRepository.GetByEvent(request.EventId);
            return _mapper.Map<List<BusinessParticipantResponse>>(participants);
        }
    }
}
