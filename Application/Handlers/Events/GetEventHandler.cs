using Application.Queries.Events;
using Application.Responses;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.Events {
    public class GetEventHandler : IRequestHandler<GetEventQuery, EventResponse> {

        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventHandler(IEventRepository eventRepository, IMapper mapper) {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<EventResponse> Handle(GetEventQuery request, CancellationToken cancellationToken) {
            var dbEvent = await _eventRepository.Get(request.Id);
            return _mapper.Map<EventResponse>(dbEvent);
        }
    }
}
