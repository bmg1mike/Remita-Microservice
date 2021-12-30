using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.SinglePayment
{
    public class SinglePaymentResponse
    {
       public string status { get; set; } 
       public string message { get; set; }
       public Data data { get; set; }
    }
    public class Data
    {
        public decimal amount { get; set; }
        public string transactionRef { get; set; }
        public string transactionDescription { get; set; }
        public string authorizationId { get; set; }
        public string transactionDate { get; set; }
        public string paymentDate { get; set; }
    }
}