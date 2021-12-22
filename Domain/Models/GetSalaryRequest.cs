namespace Domain.Models;

    public class GetSalaryRequest
    {
        public string AuthorisationCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
        public string Bvn { get; set; }
        public string AuthorisationChannel { get; set; } = "USSD";
    }
