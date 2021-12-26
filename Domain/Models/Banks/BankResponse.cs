using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.Banks
{
    public class BankResponse
    {
        public string status { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string responseId { get; set; }
        public string responseCode { get; set; }
        public string responseDescription { get; set; }
        public List<Bank> banks { get; set; }
    }

    public class Bank
    {
        public string bankCode { get; set; }
        public string bankName { get; set; }
        public string bankAccronym { get; set; }
        public string type { get; set; }
    }
}