using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.ReferenceDataService.AvailableRefData;
using Application.Features.ReferenceDataService.GetServicesByRefId;
using Domain.Models.GetServicesByRefId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ReferenceDataServiceController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ReferenceDataServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AvailableRefData")]
        public async Task<IActionResult> AvailableRefData(AvailableRefDataCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("GetServicesByRefId")]
        public async Task<IActionResult> GetServicesByRefId(GetServicesByRefIdCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}