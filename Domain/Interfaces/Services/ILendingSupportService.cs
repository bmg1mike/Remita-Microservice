using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ILendingSupportService
    {
        Task<SalaryHistoryResponse> GetSalaryHistory(GetSalaryRequest request);
    }
}