using Application.Commands.Events;
using Application.Exceptions;
using Application.Responses;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.Events {
    public class CreateEventHandler : IRequestHandler<CreateEventCommand, EventResponse> {

        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public CreateEventHandler(IEventRepository eventRepository, IMapper mapper) {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<EventResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken) {
            if (request.BeginTime < DateTime.Now) {
                throw new BadRequestException("Algusaeg peab olema tulevikus");
            }

            var newEvent = _mapper.Map<Core.Entities.Event>(request);
            await _eventRepository.Add(newEvent);
            var eventResponse = _mapper.Map<EventResponse>(newEvent);
            return eventResponse;
        }
    }
}
