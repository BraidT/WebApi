using Application.Commands.Events;
using Application.Commands.Participants;
using Application.Exceptions;
using Application.Queries.Participations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase {

        private readonly IMediator _mediator;

        public ParticipantController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet("business/{participantId}")]
        public async Task<ActionResult> GetBusinessParticipant(int participantId) {
            var result = await _mediator.Send(new GetBusinessParticipantQuery(participantId));
            return Ok(result);
        }

        [HttpGet("private/{participantId}")]
        public async Task<ActionResult> GetPrivateParticipant(int participantId) {
            var result = await _mediator.Send(new GetPrivateParticipantQuery(participantId));
            return Ok(result);
        }

        [HttpGet("business/getbyevent/{eventId}")]
        public async Task<ActionResult> GetEventBusinessParticipants(int eventId) {
            var result = await _mediator.Send(new GetEventBusinessParticipantsQuery(eventId));
            return Ok(result);
        }

        [HttpGet("private/getbyevent/{eventId}")]
        public async Task<ActionResult> GetEventPrivateParticipants(int eventId) {
            var result = await _mediator.Send(new GetEventPrivateParticipantsQuery(eventId));
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Business(CreateBusinessParticipantCommand command) {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Private(CreatePrivateParticipantCommand command) {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> Business(UpdateBusinessParticipantCommand command) {
            try {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> Private(UpdatePrivateParticipantCommand command) {
            try {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Search([FromQuery] string searchTerm) {
            var result = await _mediator.Send(new SearchParticipantsQuery(searchTerm)).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
