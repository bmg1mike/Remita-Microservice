using AutoMapper;
using Domain.Interfaces.Services;
using Domain.Models.SinglePayment;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.FundTransfer.SinglePayment
{
    public class SinglePaymentHandler : IRequestHandler<SinglePaymentCommand, SinglePaymentResponse>
    {
        private readonly IFundTransferService _service;
        private readonly ILogger<SinglePaymentHandler> _logger;
        private readonly IMapper _mapper;

        public SinglePaymentHandler(IMapper mapper, ILogger<SinglePaymentHandler> logger, IFundTransferService service)
        {
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }

        public async Task<SinglePaymentResponse> Handle(SinglePaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                 var payment = _mapper.Map<SinglePaymentRequest>(request);
                 var response = await _service.SinglePayment(payment,request.accessToken);
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