using Domain.Interfaces.Services;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.LendingSupport.GetSalaryHistory
{
    public class GetSalaryHistoryHandler : IRequestHandler<GetSalaryHistoryCommand, SalaryHistoryResponse>
    {
        private readonly ILendingSupportService _lendingService;
        private readonly ILogger<GetSalaryHistoryHandler> _logger;

        public GetSalaryHistoryHandler(ILendingSupportService lendingService, ILogger<GetSalaryHistoryHandler> logger)
        {
            _lendingService = lendingService;
            _logger = logger;
        }

        public async Task<SalaryHistoryResponse> Handle(GetSalaryHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var rnd = new Random();
                var randomNumber = rnd.Next(999999);

                 var salaryRequest = new GetSalaryRequest{
                     FirstName = request.FirstName,
                     LastName = request.LastName,
                     MiddleName = request.MiddleName,
                     AccountNumber = request.AccountNumber,
                     AuthorisationCode = randomNumber.ToString(),
                     BankCode = request.BankCode,
                     Bvn = request.Bvn
                 };

                 var result = await _lendingService.GetSalaryHistory(salaryRequest);
                 _logger.LogInformation(JsonConvert.SerializeObject(result));
                 return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return null;
            }
        }
    }
}