using Application.Features.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public class AuthController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetAccessToken")]
        public async Task<IActionResult> GetAccessToken(GenerateTokenCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}