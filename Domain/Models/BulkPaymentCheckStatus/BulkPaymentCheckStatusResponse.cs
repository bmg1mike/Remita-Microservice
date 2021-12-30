using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.BulkPaymentCheckStatus
{
    public class BulkPaymentCheckStatusResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string batchRef { get; set; }
        public decimal totalAmount { get; set; }
        public decimal feeAmount { get; set; }
        public string authorizationId { get; set; }
        public string transactionDate { get; set; }
        public string transactionDescription { get; set; }
        public string sourceAccount { get; set; }
        public string currency { get; set; }
        public string paymentStatus { get; set; }
        public List<Transaction> transactions { get; set; }
    }

    public class Transaction
    {
        public decimal amount { get; set; }
        public string transactionRef { get; set; }
        public string paymentDate { get; set; }
        public string paymentStatus { get; set; }
        public string statusMessage { get; set; }
    }
}