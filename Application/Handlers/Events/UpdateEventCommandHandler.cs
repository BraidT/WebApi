using Application.Commands.Events;
using Application.Exceptions;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Handlers.Events {
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Unit> {

        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper) {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken) {
            if (request.BeginTime < DateTime.Now) {
                throw new BadRequestException("Algusaeg peab olema tulevikus");
            }

            var existingEvent = await _eventRepository.Get(request.EventId);
            if (existingEvent == null) {
                throw new EntityNotFoundException(nameof(existingEvent), request.EventId);
             }
             _mapper.Map(request, existingEvent);
             await _eventRepository.Update(existingEvent);
             return Unit.Value;
        }
    }
}
