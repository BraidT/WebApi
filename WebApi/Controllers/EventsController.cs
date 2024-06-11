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
    public class EventsController : ControllerBase {

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

        [HttpDelete]
        public async Task<ActionResult<List<EventResponse>>> DeleteEvent(DeleteEventCommand command) {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]", Name = "AddBusinessParticipant")]
        public async Task<ActionResult<List<BusinessParticipantResponse>>> AddBusinessParticipant(AddBusinessParticipantCommand command) {
            try {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (EntityNotFoundException ex) {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("[action]", Name = "AddPrivateParticipant")]
        public async Task<ActionResult<List<BusinessParticipantResponse>>> AddPrivateParticipant(AddPrivateParticipantCommand command) {
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
