using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TransactionResponse
    {
        public decimal Amount { get; set; }
        public string RRR { get; set; }
        public string OrderId { get; set; }
        public string Message { get; set; }
        public string PaymentDate { get; set; }
        public string TransactionTime { get; set; }
        public string Status { get; set; }
    }
}