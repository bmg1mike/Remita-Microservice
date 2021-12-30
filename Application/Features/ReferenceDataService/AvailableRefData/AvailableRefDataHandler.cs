using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces.Services;
using Domain.Models.AvailableRefData;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.ReferenceDataService.AvailableRefData
{
    public class AvailableRefDataHandler : IRequestHandler<AvailableRefDataCommand, AvailableRefDataResponse>
    {
        private readonly IReferenceDataService _service;
        private readonly ILogger<AvailableRefDataHandler> _logger;
        private readonly IMapper _mapper;

        public AvailableRefDataHandler(IMapper mapper, ILogger<AvailableRefDataHandler> logger, IReferenceDataService service)
        {
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }

        public async Task<AvailableRefDataResponse> Handle(AvailableRefDataCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var response = await _service.AvailableRefData();
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