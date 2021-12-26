using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DisbursementNotificationRequest
    {
        public string customerId { get; set; }
        public string authorisationCode { get; set; }
        public string authorisationChannel { get; set; } = "USSD";
        public string phoneNumber { get; set; }
        public string accountNumber { get; set; }
        public string currency { get; set; } = "NGN";
        public decimal loanAmount { get; set; }
        public decimal collectionAmount { get; set; }
        public string dateOfDisbursement { get; set; }
        public string dateOfCollection { get; set; }
        public decimal totalCollectionAmount { get; set; }
        public int numberOfRepayments { get; set; }
        public string bankCode { get; set; }
    }
}