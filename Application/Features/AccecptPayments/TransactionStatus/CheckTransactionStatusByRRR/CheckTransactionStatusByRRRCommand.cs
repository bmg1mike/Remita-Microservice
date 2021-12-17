using Domain.Models;
using MediatR;

namespace Application.Features.AccecptPayments.TransactionStatus.CheckTransactionStatusByRRR
{
    public class CheckTransactionStatusByRRRCommand : IRequest<TransactionStatusResponse>
    {
        public string RRR { get; set; }
    }
}