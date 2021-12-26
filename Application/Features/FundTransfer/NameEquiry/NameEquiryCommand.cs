using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.NameEquiry;
using MediatR;

namespace Application.Features.FundTransfer.NameEquiry
{
    public class NameEquiryCommand : IRequest<NameEquiryResponse>
    {
        public string sourceAccount { get; set; }
        public string sourceBankCode { get; set; }
        public string accessToken { get; set; }
    }
}