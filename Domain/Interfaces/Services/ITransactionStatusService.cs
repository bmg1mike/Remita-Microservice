using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ITransactionStatusService
    {
        Task<TransactionStatusResponse>  CheckTransactionStatus(string transactionId);
        Task<TransactionResponse> CheckTransactionStatusByOrderId(string orderId);
        Task<TransactionResponse> CheckTransactionStatusByRRR(string rrr);
    }
}