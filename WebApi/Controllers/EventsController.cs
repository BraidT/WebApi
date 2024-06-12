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

        [HttpGet("{id}")]
        public async Task<ActionResult<EventResponse>> Get(int id) {
            var query = new GetEventQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<EventResponse>> CreateEvent(CreateEventCommand command) {
            try {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (BadRequestException ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEvent(UpdateEventCommand command) {
            try {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (BadRequestException ex) {
                return BadRequest(ex.Message);
            }
            catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id) {
            var result = await _mediator.Send(new DeleteEventCommand(id));
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
                return NotFound(ex.Message);
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
                return NotFound(ex.Message);
            }
        }
    }
}
