using AutoMapper;
using Domain.Interfaces.Services;
using Domain.Models.Auth;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.Authentication
{
    public class GenerateTokenHandler : IRequestHandler<GenerateTokenCommand, TokenResponse>
    {
        private readonly IAuthenticationService _service;
        private readonly ILogger<GenerateTokenHandler> _logger;
        private readonly IMapper _mapper;

        public GenerateTokenHandler(IMapper mapper, ILogger<GenerateTokenHandler> logger, IAuthenticationService service)
        {
            _mapper = mapper;
            _logger = logger;
            _service = service;
        }

        public async Task<TokenResponse> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
               var tokenRequest = _mapper.Map<TokenRequest>(request);
               var response = await _service.GetAccessToken(tokenRequest);
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