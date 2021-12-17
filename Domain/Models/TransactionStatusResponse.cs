namespace Domain.Models
{
    public class TransactionStatusResponse
    {
        public string Status { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMsg { get; set; }
        public string IResponseCode { get; set; }
        public string IResponseMessage { get; set; }
        public string AppVersionCode { get; set; }
        public List<ResponseData> ResponseData { get; set; }
        public string Data { get; set; }
    }

    public class ResponseData
    {
        public string PaymentReference { get; set; }
        public decimal Amount { get; set; }
        public string PaymentState { get; set; }
        public string PaymentDate { get; set; }
        public string ProcessorId { get; set; }
        public string TransactionId { get; set; }
        public bool Tokenized { get; set; }
        public string PaymentToken { get; set; }
        public string CardType { get; set; }
        public decimal DebitedAmount { get; set; }
        public string Message { get; set; }
        public string PaymentChannel { get; set; }
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Narration { get; set; }
    }
}