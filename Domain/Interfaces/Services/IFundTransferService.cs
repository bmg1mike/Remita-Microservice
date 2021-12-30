using Domain.Models.Banks;
using Domain.Models.BulkPayment;
using Domain.Models.BulkPaymentCheckStatus;
using Domain.Models.NameEquiry;
using Domain.Models.SinglePayment;
using Domain.Models.SinglePaymentStatusCheck;

namespace Domain.Interfaces.Services
{
    public interface IFundTransferService
    {
        Task<BankResponse> GetActiveBanks();
        Task<NameEquiryResponse> NameEquiry(NameEnquiryRequest request, string accessToken);
        Task<SinglePaymentResponse> SinglePayment(SinglePaymentRequest request, string accessToken);
        Task<SinglePaymentStatusCheckResponse> SinglePaymentCheckStatus(string transactionRef,string accessToken);
        Task<BulkPaymentResponse> BulkPayment(BulkPaymentRequest request, string accessToken);
        Task<BulkPaymentCheckStatusResponse> BulkPaymentCheckStatus(string batchRef,string accessToken);
    }
}