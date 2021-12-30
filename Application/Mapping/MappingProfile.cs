using Application.Features.Authentication;
using Application.Features.FundTransfer.BulkPayment;
using Application.Features.FundTransfer.NameEquiry;
using Application.Features.FundTransfer.SinglePayment;
using Application.Features.LendingSupport.LoanDisbursementNotification;
using Application.Features.LendingSupport.MandateHistory;
using Application.Features.LendingSupport.StopLoanCollection;
using AutoMapper;
using Domain.Models;
using Domain.Models.Auth;
using Domain.Models.BulkPayment;
using Domain.Models.MandateHistory;
using Domain.Models.NameEquiry;
using Domain.Models.SinglePayment;
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
            CreateMap<NameEquiryCommand,NameEnquiryRequest>().ReverseMap();
            CreateMap<GenerateTokenCommand,TokenRequest>().ReverseMap();
            CreateMap<SinglePaymentCommand,SinglePaymentRequest>().ReverseMap();
            CreateMap<BulkPaymentCommand,BulkPaymentRequest>().ReverseMap();
        }
    }
}