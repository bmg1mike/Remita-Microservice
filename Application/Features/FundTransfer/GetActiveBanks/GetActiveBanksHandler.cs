using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces.Services;
using Domain.Models.Banks;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.FundTransfer.GetActiveBanks
{
    public class GetActiveBanksHandler : IRequestHandler<GetActiveBanksCommand, BankResponse>
    {
        private readonly IFundTransferService _service;
        private readonly ILogger<GetActiveBanksHandler> _logger;
        private readonly IMapper _mapper;

        public GetActiveBanksHandler(IMapper mapper, ILogger<GetActiveBanksHandler> logger, IFundTransferService service)
        {
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }

        public async Task<BankResponse> Handle(GetActiveBanksCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var response = await _service.GetActiveBanks();
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