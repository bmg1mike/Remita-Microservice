using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces.Services;
using Domain.Models.NameEquiry;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.FundTransfer.NameEquiry
{
    public class NameEquiryHandler : IRequestHandler<NameEquiryCommand, NameEquiryResponse>
    {
        private readonly IFundTransferService _service;
        private readonly ILogger<NameEquiryHandler> _logger;
        private readonly IMapper _mapper;

        public NameEquiryHandler(IMapper mapper, ILogger<NameEquiryHandler> logger, IFundTransferService service)
        {
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }

        public async Task<NameEquiryResponse> Handle(NameEquiryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var enquiryRequest = _mapper.Map<NameEnquiryRequest>(request);
                 var response = await _service.NameEquiry(enquiryRequest,request.accessToken);
                 if (response is not null)
                 {
                     _logger.LogInformation(JsonConvert.SerializeObject(response));
                 }

                 return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return null;
            }
        }
    }
}