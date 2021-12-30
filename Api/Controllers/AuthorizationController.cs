using Application.Features.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public class AuthorizationController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AuthorizationController(IMediator mediator)
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