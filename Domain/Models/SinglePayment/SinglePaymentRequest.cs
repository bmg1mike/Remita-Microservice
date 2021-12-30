using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.SinglePayment
{
    public class SinglePaymentRequest
    {
        public decimal amount { get; set; }
        public string transactionRef { get; set; } 
        public string transactionDescription { get; set; }
        public string channel { get; set; }
        public string currency { get; set; } = "NGN";
        public string destinationAccount { get; set; }
        public string destinationAccountName { get; set; }
        public string destinationBankCode { get; set; }
        public string destinationEmail { get; set; }
        public string sourceAccount { get; set; }
        public string sourceAccountName { get; set; }
        public string sourceBankCode { get; set; }
        public string originalAccountNumber { get; set; }
        public string originalBankCode { get; set; }
        public string customReference { get; set; } = DateTime.Now.ToString("ddMMyyyyhhmmssss");
    }
}