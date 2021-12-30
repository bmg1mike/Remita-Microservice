using Domain.Models.BulkPaymentCheckStatus;
using MediatR;

namespace Application.Features.FundTransfer.BulkPaymentCheckStatus
{
    public class BulkPaymentCheckStatusCommand : IRequest<BulkPaymentCheckStatusResponse>
    {
        public string BatchReference { get; set; }
        public string AccessToken { get; set; }
    }
}