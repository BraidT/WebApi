using Application.Commands.Participants;
using Application.Exceptions;
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
                return NotFound();
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
                return NotFound();
            }
        }
    }
}
