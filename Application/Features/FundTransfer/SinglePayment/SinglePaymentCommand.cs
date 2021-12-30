using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.SinglePayment;
using MediatR;

namespace Application.Features.FundTransfer.SinglePayment
{
    public class SinglePaymentCommand : IRequest<SinglePaymentResponse>
    {
        public decimal amount { get; set; }
        public string transactionRef { get; set; }
        public string transactionDescription { get; set; }
        public string channel { get; set; }
        public string destinationAccount { get; set; }
        public string destinationAccountName { get; set; }
        public string destinationBankCode { get; set; }
        public string destinationEmail { get; set; }
        public string sourceAccount { get; set; }
        public string sourceAccountName { get; set; }
        public string sourceBankCode { get; set; }
        public string originalAccountNumber { get; set; }
        public string originalBankCode { get; set; }
        public string accessToken { get; set; }
    }
}