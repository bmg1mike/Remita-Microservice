using Domain.Models;
using MediatR;

namespace Application.Features.AccecptPayments.TransactionStatus.CheckTransactionStatusByRRR
{
    public class CheckTransactionStatusByRRRCommand : IRequest<TransactionResponse>
    {
        public string RRR { get; set; }
    }
}