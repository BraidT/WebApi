using Application.Commands.Events;
using Application.Commands.Participants;
using Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class EventParticipationController : ControllerBase {

        private readonly IMediator _mediator;

        public EventParticipationController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Business(CreateEventBusinessParticipantCommand command) {
            try {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (BadRequestException ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Private(CreateEventPrivateParticipantCommand command) {
            try {
                var result = await _mediator.Send(command);
                return Ok(result);
            } catch(BadRequestException ex) { 
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> Business(UpdateEventBusinessParticipantCommand command) {
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
        public async Task<ActionResult> Private(UpdateEventPrivateParticipantCommand command) {
            try {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("private/deleteEventParticipant/{eventPrivateParticipantId}")]
        public async Task<ActionResult> DeleteEventPrivateParticipant(int eventPrivateParticipantId) {
            var result = await _mediator.Send(new DeleteEventPrivateParticipantCommand(eventPrivateParticipantId));
            return Ok(result);
        }

        [HttpDelete("business/deleteEventParticipant/{eventBusinessParticipantId}")]
        public async Task<ActionResult> DeleteEventBusinessParticipant(int eventBusinessParticipantId) {
            var result = await _mediator.Send(new DeleteEventPrivateParticipantCommand(eventBusinessParticipantId));
            return Ok(result);
        }


    }
}
