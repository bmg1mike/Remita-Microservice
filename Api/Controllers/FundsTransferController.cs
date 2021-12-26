using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.FundTransfer.GetActiveBanks;
using Application.Features.FundTransfer.NameEquiry;
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
    }
}