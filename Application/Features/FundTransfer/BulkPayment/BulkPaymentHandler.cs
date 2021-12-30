using AutoMapper;
using Domain.Interfaces.Services;
using Domain.Models.BulkPayment;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.FundTransfer.BulkPayment
{
    public class BulkPaymentHandler : IRequestHandler<BulkPaymentCommand, BulkPaymentResponse>
    {
        private readonly IFundTransferService _service;
        private readonly ILogger<BulkPaymentHandler> _logger;
        private readonly IMapper _mapper;

        public BulkPaymentHandler(IMapper mapper, ILogger<BulkPaymentHandler> logger, IFundTransferService service)
        {
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }

        public async Task<BulkPaymentResponse> Handle(BulkPaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var payments = _mapper.Map<BulkPaymentRequest>(request);
                 var response = await _service.BulkPayment(payments,request.accessToken);

                 if (response is not null)
                 {
                     _logger.LogInformation(JsonConvert.SerializeObject(response));
                 }
                 return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return null;
            }
        }
    }
}