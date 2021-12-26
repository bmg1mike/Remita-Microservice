using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.LendingSupport.StopLoanCollection
{
    public class StopLoanCollectionValidator : AbstractValidator<StopLoanCollectionCommand>
    {
        public StopLoanCollectionValidator()
        {
            RuleFor(x=>x.authorisationCode).NotEmpty().NotNull();
            RuleFor(x=>x.customerId).NotNull().NotEmpty();
            RuleFor(x=>x.mandateRef).NotNull().NotEmpty();
        }
    }
}