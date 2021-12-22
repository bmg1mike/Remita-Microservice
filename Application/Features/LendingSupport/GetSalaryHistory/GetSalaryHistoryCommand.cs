using Domain.Models;
using MediatR;

namespace Application.Features.LendingSupport.GetSalaryHistory
{
    public class GetSalaryHistoryCommand : IRequest<SalaryHistoryResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
        public string Bvn { get; set; }
    }
}