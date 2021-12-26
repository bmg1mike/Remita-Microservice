using AutoMapper;
using Domain.Interfaces.Services;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.LendingSupport.LoanDisbursementNotification
{
    public class LoanDisbursementNotificationHandler : IRequestHandler<LoanDisbursementNotificationCommand, DisbursementNotificationResponse>
    {
        private readonly ILendingSupportService _service;
        private readonly ILogger<LoanDisbursementNotificationHandler> _logger;
        private readonly IMapper _mapper;
        public LoanDisbursementNotificationHandler(ILendingSupportService service, ILogger<LoanDisbursementNotificationHandler> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DisbursementNotificationResponse> Handle(LoanDisbursementNotificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var notificationRequest = _mapper.Map<DisbursementNotificationRequest>(request);
                var response = await _service.LoanDisbursementNotification(notificationRequest);
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