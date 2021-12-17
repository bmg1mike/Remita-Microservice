using Domain.Models;
using MediatR;

namespace Application.Features.AccecptPayments.TransactionStatus.CheckTransactionStatusByOrderId
{
    public class CheckTransactionStatusByOrderIdCommand : IRequest<TransactionResponse>
    {
        public string OrderId { get; set; }
    }
}