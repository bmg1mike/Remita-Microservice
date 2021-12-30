using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.GetServicesByRefId
{
    public class ServicesByRefIdResponse
    {
        public string status { get; set; }
        public string responseCode { get; set; }
        public string responseMsg { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public List<CustomField> customFields { get; set; }
        public string refId { get; set; }
    }
    public class CustomField
    {
        public string description { get; set; }
        public string value { get; set; }
        public string key { get; set; }
        public bool required { get; set; }
        public string keyType { get; set; }
        public List<ValueOption> valueOptions { get; set; }
    }
    public class ValueOption
    {
        public string description { get; set; }
        public string value { get; set; }
    }
}