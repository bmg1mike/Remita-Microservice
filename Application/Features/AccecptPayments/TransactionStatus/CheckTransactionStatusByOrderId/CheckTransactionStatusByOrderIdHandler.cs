using Domain.Interfaces.Services;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AccecptPayments.TransactionStatus.CheckTransactionStatusByOrderId
{
    public class CheckTransactionStatusByOrderIdHandler : IRequestHandler<CheckTransactionStatusByOrderIdCommand, TransactionResponse>
    {
        private readonly ITransactionStatusService _transactionService;
        private readonly ILogger<CheckTransactionStatusByOrderIdHandler> _logger;

        public CheckTransactionStatusByOrderIdHandler(ILogger<CheckTransactionStatusByOrderIdHandler> logger, ITransactionStatusService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        public async Task<TransactionResponse> Handle(CheckTransactionStatusByOrderIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var status = await _transactionService.CheckTransactionStatusByOrderId(request.OrderId);

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