using Domain.Models;
using MediatR;

namespace Application.Features.AccecptPayments.TransactionStatus.CheckTransactionStatusByTransactionId
{
    public class CheckTransactionStatusByTransactionIdCommand : IRequest<TransactionStatusResponse>
    {
        public string TransactionId { get; set; }
    }
}