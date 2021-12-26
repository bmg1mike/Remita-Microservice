using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.MandateHistory
{
    public class MandateHistoryResponse
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
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string loanMandateReference { get; set; }
        public decimal totalDisbursed { get; set; }
        public decimal outstandingLoanBal { get; set; }
        public string loanRepaymentRef { get; set; }
        public string employerName { get; set; }
        public string salaryAccount { get; set; }
        public string authorisationCode { get; set; }
        public string salaryBankCode { get; set; }
        public string disbursementAccountBank { get; set; }
        public string collectionStartDate { get; set; }
        public string dateOfDisbursement { get; set; }
        public string disbursementAccount { get; set; }
        public string status { get; set; }
        public string lenderDetails { get; set; }
        public string repayment { get; set; }
    }
}