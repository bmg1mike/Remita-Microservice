using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.StopLoanCollection;
using MediatR;

namespace Application.Features.LendingSupport.StopLoanCollection
{
    public class StopLoanCollectionCommand : IRequest<StopLoanCollectionResponse>
    {
        public string authorisationCode { get; set; }
        public string customerId { get; set; }
        public string mandateRef { get; set; }
    }
}