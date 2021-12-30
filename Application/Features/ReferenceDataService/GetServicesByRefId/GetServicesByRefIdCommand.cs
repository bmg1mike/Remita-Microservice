using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.GetServicesByRefId;
using MediatR;

namespace Application.Features.ReferenceDataService.GetServicesByRefId
{
    public class GetServicesByRefIdCommand : IRequest<ServicesByRefIdResponse>
    {
        public string RefId { get; set; }
    }
}