using Application.Features.LendingSupport.GetSalaryHistory;
using Application.Features.LendingSupport.LoanDisbursementNotification;
using Application.Features.LendingSupport.MandateHistory;
using Application.Features.LendingSupport.StopLoanCollection;
using Domain.Models;
using Domain.Models.MandateHistory;
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

        [HttpPost("LoanDisbursementNotification")]
        [ProducesResponseType(200,Type = typeof(DisbursementNotificationResponse))]
        public async Task<IActionResult> LoanDisbursementNotification(LoanDisbursementNotificationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("MandateHistory")]
        //[ProducesResponseType(200,Type = typeof(MandateHistoryResponse))]
        public async Task<IActionResult> MandateHistory(MandateHistoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("StopLoanCollection")]
        public async Task<IActionResult> StopLoanCollection(StopLoanCollectionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}