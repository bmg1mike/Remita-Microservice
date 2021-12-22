using Application.Features.LendingSupport.GetSalaryHistory;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class LendingSupportController : BaseApiController
    {
        private readonly IMediator _mediator;

        public LendingSupportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetSalaryHistory")]
        [ProducesResponseType(200,Type = typeof(SalaryHistoryResponse))]
        public async Task<IActionResult> GetSalaryHistory(GetSalaryHistoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}