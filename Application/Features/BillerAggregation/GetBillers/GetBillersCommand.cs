using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.GetBillers;
using MediatR;

namespace Application.Features.BillerAggregation.GetBillers
{
    public class GetBillersCommand : IRequest<GetBillersResponse>
    {
        
    }
}