using Application.Queries.Participations;
using Application.Responses;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.Participants {
    public class GetPrivateParticipantsByEventHandler : IRequestHandler<GetEventPrivateParticipantsQuery, List<EventPrivateParticipantResponse>> {

        private readonly IEventPrivateParticipantRepository _eventPrivateParticipantRepository;
        private readonly IMapper _mapper;

        public GetPrivateParticipantsByEventHandler(IEventPrivateParticipantRepository eventPrivateParticipantRepository, IMapper mapper) {
            _eventPrivateParticipantRepository = eventPrivateParticipantRepository;
            _mapper = mapper;
        }
        public async Task<List<EventPrivateParticipantResponse>> Handle(GetEventPrivateParticipantsQuery request, CancellationToken cancellationToken) {
            var participants = await _eventPrivateParticipantRepository.GetByEvent(request.EventId);
            return _mapper.Map<List<EventPrivateParticipantResponse>>(participants);
        }
    }
}
