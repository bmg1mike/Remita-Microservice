using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.MandateHistory;
using Domain.Models.StopLoanCollection;

namespace Domain.Interfaces.Services
{
    public interface ILendingSupportService
    {
        Task<SalaryHistoryResponse> GetSalaryHistory(GetSalaryRequest request);
        Task<DisbursementNotificationResponse> LoanDisbursementNotification(DisbursementNotificationRequest request);
        Task<MandateHistoryResponse> MandateHistory(MandateHistoryRequest request);
        Task<StopLoanCollectionResponse> StopLoanCollection(StopLoanCollectionRequest request);
    }
}