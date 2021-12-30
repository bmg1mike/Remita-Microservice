using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.BulkPayment;
using MediatR;

namespace Application.Features.FundTransfer.BulkPayment
{
    public class BulkPaymentCommand : IRequest<BulkPaymentResponse>
    {
        public string batchRef { get; set; }
        public decimal totalAmount { get; set; }
        public string sourceAccount { get; set; }
        public string sourceAccountName { get; set; }
        public string sourceBankCode { get; set; }
        public string sourceNarration { get; set; }
        public string originalAccountNumber { get; set; }
        public string originalBankCode { get; set; }
        public string customReference { get; set; }
        public List<Transaction> transactions { get; set; }
        public string accessToken { get; set; }
    }
}