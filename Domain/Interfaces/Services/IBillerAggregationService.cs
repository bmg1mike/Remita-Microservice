using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.GetBillers;

namespace Domain.Interfaces.Services
{
    public interface IBillerAggregationService
    {
        Task<GetBillersResponse> GetBillers();
    }
}