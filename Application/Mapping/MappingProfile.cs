using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.LendingSupport.LoanDisbursementNotification;
using Application.Features.LendingSupport.MandateHistory;
using Application.Features.LendingSupport.StopLoanCollection;
using AutoMapper;
using Domain.Models;
using Domain.Models.MandateHistory;
using Domain.Models.StopLoanCollection;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoanDisbursementNotificationCommand,DisbursementNotificationRequest>().ReverseMap();
            CreateMap<MandateHistoryCommand,MandateHistoryRequest>().ReverseMap();
            CreateMap<StopLoanCollectionRequest,StopLoanCollectionCommand>().ReverseMap();
        }
    }
}