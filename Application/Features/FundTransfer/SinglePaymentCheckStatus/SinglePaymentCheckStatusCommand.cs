using Domain.Models.SinglePaymentStatusCheck;
using MediatR;

namespace Application.Features.FundTransfer.SinglePaymentCheckStatus
{
    public class SinglePaymentCheckStatusCommand : IRequest<SinglePaymentStatusCheckResponse>
    {
        public string TransactionReference { get; set; }
        public string AccessToken { get; set; }
    }
}