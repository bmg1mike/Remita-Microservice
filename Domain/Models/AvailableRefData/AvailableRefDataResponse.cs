using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.AvailableRefData
{
    public class AvailableRefDataResponse
    {
        public string status { get; set; }
        public string responseCode { get; set; }
        public string responseMsg { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string refId { get; set; }
        public string description { get; set; }
    }
}