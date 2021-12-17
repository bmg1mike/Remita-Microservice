using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ITransactionStatusService
    {
        Task<TransactionStatusResponse>  CheckTransactionStatus(string transactionId);
    }
}