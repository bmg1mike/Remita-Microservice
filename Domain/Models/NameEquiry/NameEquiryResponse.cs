using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.NameEquiry
{
    public class NameEquiryResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string sourceAccount { get; set; }
        public string sourceAccountName { get; set; }
        public string sourceBankCode { get; set; }
    }
}