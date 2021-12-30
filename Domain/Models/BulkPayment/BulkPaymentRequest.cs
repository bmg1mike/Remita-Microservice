using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.BulkPayment
{
    public class BulkPaymentRequest
    {
        public string batchRef { get; set; }
        public decimal totalAmount { get; set; }
        public string sourceAccount { get; set; }
        public string sourceAccountName { get; set; }
        public string sourceBankCode { get; set; }
        public string currency { get; set; } = "NGN";
        public string sourceNarration { get; set; }
        public string originalAccountNumber { get; set; }
        public string originalBankCode { get; set; }
        public string customReference { get; set; }
        public List<Transaction> transactions { get; set; }
    }

    public class Transaction
    {
        public decimal amount { get; set; }
        public string transactionRef { get; set; }
        public string destinationAccount { get; set; }
        public string destinationAccountName { get; set; }
        public string destinationBankCode { get; set; }
        public string destinationNarration { get; set; }
    }
}