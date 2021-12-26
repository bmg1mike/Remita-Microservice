using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.NameEquiry
{
    public class NameEnquiryRequest
    {
        public string sourceAccount { get; set; }
        public string sourceBankCode { get; set; }
    }
}