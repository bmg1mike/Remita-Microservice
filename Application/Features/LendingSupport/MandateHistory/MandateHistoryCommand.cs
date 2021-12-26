using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.MandateHistory;
using MediatR;

namespace Application.Features.LendingSupport.MandateHistory
{
    public class MandateHistoryCommand : IRequest<MandateHistoryResponse>
    {
        public string authorisationCode { get; set; }
        public string customerId { get; set; }
        public string mandateRef { get; set; }
    }
}