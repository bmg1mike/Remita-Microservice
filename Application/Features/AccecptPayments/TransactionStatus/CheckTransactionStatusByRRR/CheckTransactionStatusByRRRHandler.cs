using Domain.Interfaces.Services;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AccecptPayments.TransactionStatus.CheckTransactionStatusByRRR
{
    public class CheckTransactionStatusByRRRHandler : IRequestHandler<CheckTransactionStatusByRRRCommand, TransactionResponse>
    {
        private readonly ITransactionStatusService _transactionService;
        private readonly ILogger<CheckTransactionStatusByRRRHandler> _logger;

        public CheckTransactionStatusByRRRHandler(ILogger<CheckTransactionStatusByRRRHandler> logger, ITransactionStatusService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        public async Task<TransactionResponse> Handle(CheckTransactionStatusByRRRCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var status = await _transactionService.CheckTransactionStatusByRRR(request.RRR);
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