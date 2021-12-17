using Application.Features.AccecptPayments.TransactionStatus.CheckTransactionStatusByOrderId;
using Application.Features.AccecptPayments.TransactionStatus.CheckTransactionStatusByRRR;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AccecptPayments
{
    public class CheckTransactionStatusController : BaseApiController
    {
        private readonly IMediator _mediator;

        public CheckTransactionStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CheckTransactionStatusByOrderId")]
        [ProducesResponseType(200,Type = typeof(TransactionResponse))]
        public async Task<IActionResult> CheckTransactionStatusByOrderId(CheckTransactionStatusByOrderIdCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("CheckTransactionStatusByRRR")]
        [ProducesResponseType(200,Type = typeof(TransactionResponse))]
        public async Task<IActionResult> CheckTransactionStatusByRRR(CheckTransactionStatusByRRRCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}