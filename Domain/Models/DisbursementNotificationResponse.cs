using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DisbursementNotificationResponse
    {
        public string status { get; set; }
        public bool hasData { get; set; }
        public string responseId { get; set; }
        public string responseDate { get; set; }
        public string requestDate { get; set; }
        public string responseCode { get; set; }
        public string responseMsg { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string customerId { get; set; }
        public string accountNumber { get; set; }
        public string bankCode { get; set; }
        public string bvn { get; set; }
        public string companyName { get; set; }
        public string category { get; set; }
        public string firstPaymentDate { get; set; }
        public string salaryCount { get; set; }
        public List<SalaryPaymentDetails> salaryPaymentDetails { get; set; }
        public List<LoanHistoryDetails> loanHistoryDetails { get; set; }
        public string originalCustomerId { get; set; }
    }

    public class SalaryPaymentDetails
    {
        public string paymentDate { get; set; }
        public string amount { get; set; }
        public string accountNumber { get; set; }
        public string bankCode { get; set; }
    }

    public class LoanHistoryDetails
    {
        public string loanProvider { get; set; }
        public decimal loanAmount { get; set; }
        public decimal outstandingAmount { get; set; }
        public string loanDisbursementDate { get; set; }
        public string status { get; set; }
        public decimal repaymentAmount { get; set; }
        public string repaymentFreq { get; set; }
    }
    
}