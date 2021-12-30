using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.BulkPayment
{
    public class BulkPaymentResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string batchRef { get; set; }
        public decimal totalAmount { get; set; }
        public string authorizationId { get; set; }
        public string transactionDate { get; set; }
    }
}