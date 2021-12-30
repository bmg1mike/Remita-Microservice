using Domain.Interfaces.Services;
using Domain.Models.BulkPaymentCheckStatus;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.FundTransfer.BulkPaymentCheckStatus
{
    public class BulkPaymentCheckStatusHandler : IRequestHandler<BulkPaymentCheckStatusCommand, BulkPaymentCheckStatusResponse>
    {
        private readonly IFundTransferService _service;
        private readonly ILogger<BulkPaymentCheckStatusHandler> _logger;

        public BulkPaymentCheckStatusHandler(ILogger<BulkPaymentCheckStatusHandler> logger, IFundTransferService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<BulkPaymentCheckStatusResponse> Handle(BulkPaymentCheckStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var response = await _service.BulkPaymentCheckStatus(request.BatchReference,request.AccessToken);
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