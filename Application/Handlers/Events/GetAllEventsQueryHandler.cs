using Application.Queries.Events;
using Application.Responses;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.Event {
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, List<EventResponse>> {

        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetAllEventsQueryHandler(IEventRepository eventRepository, IMapper mapper) {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<List<EventResponse>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken) {
            var events = await _eventRepository.GetAll();
            return _mapper.Map<List<EventResponse>>(events);
        }
    }
}
