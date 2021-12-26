using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces.Services;
using Domain.Models.StopLoanCollection;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.LendingSupport.StopLoanCollection
{
    public class StopLoanCollectionHandler : IRequestHandler<StopLoanCollectionCommand, StopLoanCollectionResponse>
    {
        private readonly ILendingSupportService _service;
        private readonly ILogger<StopLoanCollectionHandler> _logger;
        private readonly IMapper _mapper;

        public StopLoanCollectionHandler(ILendingSupportService service, ILogger<StopLoanCollectionHandler> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<StopLoanCollectionResponse> Handle(StopLoanCollectionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var collection = _mapper.Map<StopLoanCollectionRequest>(request);
                 var response = await _service.StopLoanCollection(collection);

                 if (response is not null)
                 {
                     _logger.LogInformation(JsonConvert.SerializeObject(collection));
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