using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Banks;
using Domain.Models.NameEquiry;

namespace Domain.Interfaces.Services
{
    public interface IFundTransferService
    {
        Task<BankResponse> GetActiveBanks();
        Task<NameEquiryResponse> NameEquiry(NameEnquiryRequest request, string accessToken);
    }
}