using Domain.Interfaces.Services;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.AccecptPayments.TransactionStatus.CheckTransactionStatusByTransactionId
{
    public class CheckTransactionStatusByTransactionIdHandler : IRequestHandler<CheckTransactionStatusByTransactionIdCommand, TransactionStatusResponse>
    {
        private readonly ITransactionStatusService _transactionStatus;
        private readonly ILogger<CheckTransactionStatusByTransactionIdHandler> _logger;

        public CheckTransactionStatusByTransactionIdHandler(ITransactionStatusService transactionStatus, ILogger<CheckTransactionStatusByTransactionIdHandler> logger)
        {
            _transactionStatus = transactionStatus;
            _logger = logger;
        }

        public async Task<TransactionStatusResponse> Handle(CheckTransactionStatusByTransactionIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var status = await _transactionStatus.CheckTransactionStatus(request.TransactionId);
                 
                 _logger.LogInformation(JsonConvert.SerializeObject(status));
                 return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}