using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Models.Banks;
using Domain.Models.NameEquiry;
using Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace Infrastructure.Services
{
    public class FundTransferService : IFundTransferService
    {
        private readonly IHttpCommunication _client;
        private readonly ILogger<FundTransferService> _logger;
        private readonly IConfiguration _config;

        public FundTransferService(IConfiguration config, ILogger<FundTransferService> logger, IHttpCommunication client)
        {
            _config = config;
            _logger = logger;
            _client = client;
        }

        public async Task<BankResponse> GetActiveBanks()
        {
            try
            {
                 var hostUrl = "https://remitademo.net/remita/exapp/api/v1/send/api/rpgsvc/rpg/api/v2/fi/banks";
                 var requestId = DateTime.Now.ToString("ddMMyyyyhhmmssss");
                 var requestTs = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss+000000");
                 var merchantId = "DEMOMDA1234";
                 var apiKey = "REVNT01EQTEyMzR8REVNT01EQQ";
                 var apiToken = "bmR1ZFFFWEx5R2c2NmhnMEk5a25WenJaZWZwbHFFYldKOGY0bHlGZnBZQ1N5WEpXU2Y1dGt3PT0=";
                 var apiHash = Hashing.HashSha512Data(apiKey+requestId+apiToken);
                 var headers = new Dictionary<string,string>();
                 headers.Add("Content-Type", "application/json");
                 headers.Add("API_KEY", apiKey);
                 headers.Add("REQUEST_ID",requestId);
                 headers.Add("REQUEST_TS",requestTs);
                 headers.Add("API_DETAILS_HASH",apiHash);

                 var response = await _client.HttpAsync(Method.POST,hostUrl,headers,null);
                 if (response.IsSuccessful)
                 {
                     var result = response.Content;
                     return JsonConvert.DeserializeObject<BankResponse>(result);
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

        public async Task<NameEquiryResponse> NameEquiry(NameEnquiryRequest request, string accessToken)
        {
            try
            {
                 var hostUrl = "https://remitademo.net/remita/exapp/api/v1/send/api/rpgsvc/v3/rpg/account/lookup";
                 var headers = new Dictionary<string,string>();
                 headers.Add("Authorization", $"Bearer {accessToken}");
                 var response = await _client.HttpAsync(Method.POST,hostUrl,headers,request);
                 if (response.IsSuccessful)
                 {
                     var result = response.Content;
                     return JsonConvert.DeserializeObject<NameEquiryResponse>(result);
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