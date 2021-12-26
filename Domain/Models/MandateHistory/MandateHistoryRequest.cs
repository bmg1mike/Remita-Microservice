namespace Domain.Models.MandateHistory
{
    public class MandateHistoryRequest
    {
        public string authorisationCode { get; set; }
        public string customerId { get; set; }
        public string mandateRef { get; set; }
    }
}