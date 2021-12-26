using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SalaryHistoryResponse
    {
        public string Status { get; set; }
        public bool HasData { get; set; }
        public string responseId { get; set; }
        public string responseDate { get; set; }
        public string requestDate { get; set; }
        public string responseCode { get; set; }
        public string responseMsg { get; set; }
        public Data Data { get; set; }
    }

    // public class Data
    // {
    //     public string customerId { get; set; }
    //     public string accountNumber { get; set; }
    //     public string bankCode { get; set; }
    //     public string bvn { get; set; }
    //     public string companyName { get; set; }
    //     public string category { get; set; }
    //     public string firstPaymentDate { get; set; }
    //     public string salaryCount { get; set; }
    //     public List<SalaryPaymentDetail> salaryPaymentDetails { get; set; }
    // }

    // public class SalaryPaymentDetail
    // {
    //     public string paymentDate { get; set; }
    //     public string amount { get; set; }
    //     public string accountNumber { get; set; }
    //     public string bankCode { get; set; }
    // }
}