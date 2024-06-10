using Application.Commands.Events;
using Application.Exceptions;
using Application.Queries.Events;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace WebApi.Controllers {
    
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController: ControllerBase {

        private readonly IMediator _mediator;

        public EventsController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventResponse>>> GetAllEvents() {
            var query = new GetAllEventsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<EventResponse>>> CreateEvent(CreateEventCommand command) {
             var result = await _mediator.Send(command);
             return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<EventResponse>>> UpdateEvent(UpdateEventCommand command) {
            try {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (EntityNotFoundException ex) {
                return NotFound();
            }
        }
    }
}
