using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.StopLoanCollection
{
    public class StopLoanCollectionRequest
    {
        public string authorisationCode { get; set; }
        public string customerId { get; set; }
        public string mandateRef { get; set; }
    }
}