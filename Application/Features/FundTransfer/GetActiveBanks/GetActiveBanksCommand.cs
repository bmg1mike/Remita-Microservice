using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Banks;
using MediatR;

namespace Application.Features.FundTransfer.GetActiveBanks
{
    public class GetActiveBanksCommand : IRequest<BankResponse>
    {
        
    }
}