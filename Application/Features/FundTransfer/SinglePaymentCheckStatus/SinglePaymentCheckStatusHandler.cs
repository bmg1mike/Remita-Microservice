using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Services;
using Domain.Models.SinglePaymentStatusCheck;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.FundTransfer.SinglePaymentCheckStatus
{
    public class SinglePaymentCheckStatusHandler : IRequestHandler<SinglePaymentCheckStatusCommand, SinglePaymentStatusCheckResponse>
    {
        private readonly IFundTransferService _service;
        private readonly ILogger<SinglePaymentCheckStatusHandler> _logger;

        public SinglePaymentCheckStatusHandler(ILogger<SinglePaymentCheckStatusHandler> logger, IFundTransferService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<SinglePaymentStatusCheckResponse> Handle(SinglePaymentCheckStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var response = await _service.SinglePaymentCheckStatus(request.TransactionReference,request.AccessToken);
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