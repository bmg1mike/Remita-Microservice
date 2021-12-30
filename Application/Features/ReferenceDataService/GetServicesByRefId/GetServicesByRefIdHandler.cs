using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces.Services;
using Domain.Models.GetServicesByRefId;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.ReferenceDataService.GetServicesByRefId
{
    public class GetServicesByRefIdHandler : IRequestHandler<GetServicesByRefIdCommand, ServicesByRefIdResponse>
    {
        private readonly IReferenceDataService _service;
        private readonly ILogger<GetServicesByRefIdHandler> _logger;
        private readonly IMapper _mapper;

        public GetServicesByRefIdHandler(IMapper mapper, ILogger<GetServicesByRefIdHandler> logger, IReferenceDataService service)
        {
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }

        public async Task<ServicesByRefIdResponse> Handle(GetServicesByRefIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var response = await _service.GetServicesByRefId(request.RefId);
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