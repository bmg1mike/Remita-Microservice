using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.AvailableRefData;
using Domain.Models.GetServicesByRefId;

namespace Domain.Interfaces.Services
{
    public interface IReferenceDataService
    {
        Task<AvailableRefDataResponse> AvailableRefData();
        Task<ServicesByRefIdResponse> GetServicesByRefId(string refId);
    }
}