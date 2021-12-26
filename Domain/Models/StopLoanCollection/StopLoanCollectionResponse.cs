using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.StopLoanCollection
{
    public class StopLoanCollectionResponse
    {
        public string status { get; set; }
        public bool hasData { get; set; }
        public string responseId { get; set; }
        public string responseDate { get; set; }
        public string requestDate { get; set; }
        public string responseCode { get; set; }
        public string responseMsg { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string customerId { get; set; }
        public string status { get; set; }
        public string mandateReference { get; set; }
    }
}
