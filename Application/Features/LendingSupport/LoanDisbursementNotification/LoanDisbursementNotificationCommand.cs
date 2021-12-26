using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;

namespace Application.Features.LendingSupport.LoanDisbursementNotification
{
    public class LoanDisbursementNotificationCommand : IRequest<DisbursementNotificationResponse>
    {
        public string customerId { get; set; }
        public string authorisationCode { get; set; }
        public string phoneNumber { get; set; }
        public string accountNumber { get; set; }
        public decimal loanAmount { get; set; }
        public decimal collectionAmount { get; set; }
        public string dateOfDisbursement { get; set; }
        public string dateOfCollection { get; set; }
        public decimal totalCollectionAmount { get; set; }
        public int numberOfRepayments { get; set; }
        public string bankCode { get; set; }
    }
}