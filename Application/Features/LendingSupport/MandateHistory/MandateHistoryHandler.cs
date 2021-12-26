using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces.Services;
using Domain.Models.MandateHistory;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.LendingSupport.MandateHistory
{
    public class MandateHistoryHandler : IRequestHandler<MandateHistoryCommand, MandateHistoryResponse>
    {
        private readonly ILendingSupportService _service;
        private readonly ILogger<MandateHistoryHandler> _logger;
        private readonly IMapper _mapper;

        public MandateHistoryHandler(IMapper mapper, ILogger<MandateHistoryHandler> logger, ILendingSupportService service)
        {
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }

        public async Task<MandateHistoryResponse> Handle(MandateHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var history = _mapper.Map<MandateHistoryRequest>(request);
                 var result = await _service.MandateHistory(history);
                 if (result is not null)
                 {
                     _logger.LogInformation(JsonConvert.SerializeObject(result)); 
                 }

                 return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return null;
            }
        }
    }
}