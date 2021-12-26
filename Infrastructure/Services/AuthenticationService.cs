using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Models.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpCommunication _client;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IConfiguration _config;

        public AuthenticationService(IConfiguration config, ILogger<AuthenticationService> logger, IHttpCommunication client)
        {
            _config = config;
            _logger = logger;
            _client = client;
        }

        public async Task<TokenResponse> GetAccessToken(TokenRequest request)
        {
            try
            {
                 var hostUrl = "https://remitademo.net/remita/exapp/api/v1/send/api/uaasvc/uaa/token";
                 var headers = new Dictionary<string,string>();
                 headers.Add("Content-Type", "application/json");
                 var response = await _client.HttpAsync(Method.POST,hostUrl,headers,request);
                 if(response.IsSuccessful)
                 {
                     var result = response.Content;
                     return JsonConvert.DeserializeObject<TokenResponse>(result);
                 }
                 _logger.LogInformation($"The response was not successful.{response.Content}");
                 return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}