using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.FundTransfer.BulkPayment;
using Application.Features.FundTransfer.BulkPaymentCheckStatus;
using Application.Features.FundTransfer.GetActiveBanks;
using Application.Features.FundTransfer.NameEquiry;
using Application.Features.FundTransfer.SinglePayment;
using Application.Features.FundTransfer.SinglePaymentCheckStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class FundsTransferController : BaseApiController
    {
        private readonly IMediator _mediator;

        public FundsTransferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetActiveBanks")]
        public async Task<IActionResult> GetActiveBanks(GetActiveBanksCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("NameEnquiry")]
        public async Task<IActionResult> NameEnquiry(NameEquiryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("SinglePayment")]
        public async Task<IActionResult> SinglePayment(SinglePaymentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("SinglePaymentCheckStatus")]
        public async Task<IActionResult> SinglePaymentCheckStatus(SinglePaymentCheckStatusCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("BulkPayment")]
        public async Task<IActionResult> BulkPayment(BulkPaymentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("BulkPaymentCheckStatus")]
        public async Task<IActionResult> BulkPaymentCheckStatus(BulkPaymentCheckStatusCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}