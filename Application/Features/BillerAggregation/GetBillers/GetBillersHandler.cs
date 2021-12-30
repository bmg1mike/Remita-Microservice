using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces.Services;
using Domain.Models.GetBillers;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.BillerAggregation.GetBillers
{
    public class GetBillersHandler : IRequestHandler<GetBillersCommand, GetBillersResponse>
    {
        private readonly IBillerAggregationService _service;
        private readonly ILogger<GetBillersHandler> _logger;
        private readonly IMapper _mapper;

        public GetBillersHandler(ILogger<GetBillersHandler> logger, IBillerAggregationService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<GetBillersResponse> Handle(GetBillersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _service.GetBillers();
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