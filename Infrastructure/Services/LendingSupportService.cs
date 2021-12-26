using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Models.MandateHistory;
using Domain.Models.StopLoanCollection;
using Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace Infrastructure.Services
{

    public class LendingSupportService : ILendingSupportService
    {
        private readonly IHttpCommunication _client;
        private readonly ILogger<LendingSupportService> _logger;
        private readonly IConfiguration _config;

        public LendingSupportService(ILogger<LendingSupportService> logger, IHttpCommunication client, IConfiguration config)
        {
            _logger = logger;
            _client = client;
            _config = config;
        }

        public async Task<SalaryHistoryResponse> GetSalaryHistory(GetSalaryRequest request)
        {
            try
            {
                var hostUrl = "https://remitademo.net/remita/exapp/api/v1/send/api/loansvc/data/api/v2/payday/salary/history/provideCustomerDetails";
                var merchantId = "27768931";
                var apiKey = "Q1dHREVNTzEyMzR8Q1dHREVNTw==";
                var apiToken = "SGlQekNzMEdMbjhlRUZsUzJCWk5saDB6SU14Zk15djR4WmkxaUpDTll6bGIxRCs4UkVvaGhnPT0=";
                var requestId = DateTime.Now.ToString("ddMMyyyyhhmmssss");
                var apiHash = Hashing.HashSha512Data(apiKey + requestId + apiToken);
                var headers = new Dictionary<string, string>();
                headers.Add("Content-Type", "application/json");
                headers.Add("API_KEY", apiKey);
                headers.Add("MERCHANT_ID", merchantId);
                headers.Add("REQUEST_ID", requestId);
                headers.Add("AUTHORIZATION", "remitaConsumerKey=" + apiKey + ", remitaConsumerToken="+apiHash);
                var response = await _client.HttpAsync(Method.POST, hostUrl, headers, request);

                if (response.IsSuccessful)
                {
                    var result = response.Content;
                    return JsonConvert.DeserializeObject<SalaryHistoryResponse>(result);
                }

                _logger.LogInformation($"The response was not successful. {response.Content}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<DisbursementNotificationResponse> LoanDisbursementNotification(DisbursementNotificationRequest request)
        {
            try
            {
                 var hostUrl = "https://remitademo.net/remita/exapp/api/v1/send/api/loansvc/data/api/v2/payday/post/loan";
                var merchantId = "27768931";
                var apiKey = "Q1dHREVNTzEyMzR8Q1dHREVNTw==";
                var apiToken = "SGlQekNzMEdMbjhlRUZsUzJCWk5saDB6SU14Zk15djR4WmkxaUpDTll6bGIxRCs4UkVvaGhnPT0=";
                var requestId = DateTime.Now.ToString("ddMMyyyyhhmmssss");
                var apiHash = Hashing.HashSha512Data(apiKey + requestId + apiToken);
                var headers = new Dictionary<string, string>();
                headers.Add("Content-Type", "application/json");
                headers.Add("API_KEY", apiKey);
                headers.Add("MERCHANT_ID", merchantId);
                headers.Add("REQUEST_ID", requestId);
                headers.Add("AUTHORIZATION", "remitaConsumerKey=" + apiKey + ",remitaConsumerToken="+apiHash);

                var response = await _client.HttpAsync(Method.POST,hostUrl,headers,request);
                if(response.IsSuccessful)
                {
                    var result = response.Content;
                    return JsonConvert.DeserializeObject<DisbursementNotificationResponse>(result);
                }
                _logger.LogInformation($"The response was not successful.{response.Content}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw new Exception(ex.Message);
                throw;
            }
        }

        public async Task<MandateHistoryResponse> MandateHistory(MandateHistoryRequest request)
        {
            try
            {
                var hostUrl = "https://remitademo.net/remita/exapp/api/v1/send/api/loansvc/data/api/v2/payday/loan/payment/history";
                var merchantId = "27768931";
                var apiKey = "Q1dHREVNTzEyMzR8Q1dHREVNTw==";
                var apiToken = "SGlQekNzMEdMbjhlRUZsUzJCWk5saDB6SU14Zk15djR4WmkxaUpDTll6bGIxRCs4UkVvaGhnPT0=";
                var requestId = DateTime.Now.ToString("ddMMyyyyhhmmssss");
                var apiHash = Hashing.HashSha512Data(apiKey + requestId + apiToken);
                var headers = new Dictionary<string, string>();
                headers.Add("Content-Type", "application/json");
                headers.Add("API_KEY", apiKey);
                headers.Add("MERCHANT_ID", merchantId);
                headers.Add("REQUEST_ID", requestId);
                headers.Add("AUTHORIZATION", "remitaConsumerKey=" + apiKey + ", remitaConsumerToken="+apiHash);
                var response = await _client.HttpAsync(Method.POST,hostUrl,headers,request);
                if (response.IsSuccessful)
                {
                    var result = response.Content;
                    return JsonConvert.DeserializeObject<MandateHistoryResponse>(result);
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

        public async Task<StopLoanCollectionResponse> StopLoanCollection(StopLoanCollectionRequest request)
        {
            try
            {
                var hostUrl = "https://remitademo.net/remita/exapp/api/v1/send/api/loansvc/data/api/v2/payday/stop/loan";
                var merchantId = "27768931";
                var apiKey = "Q1dHREVNTzEyMzR8Q1dHREVNTw==";
                var apiToken = "SGlQekNzMEdMbjhlRUZsUzJCWk5saDB6SU14Zk15djR4WmkxaUpDTll6bGIxRCs4UkVvaGhnPT0=";
                var requestId = DateTime.Now.ToString("ddMMyyyyhhmmssss");
                var apiHash = Hashing.HashSha512Data(apiKey + requestId + apiToken);
                var headers = new Dictionary<string, string>();
                headers.Add("Content-Type", "application/json");
                headers.Add("API_KEY", apiKey);
                headers.Add("MERCHANT_ID", merchantId);
                headers.Add("REQUEST_ID", requestId);
                headers.Add("AUTHORIZATION", "remitaConsumerKey=" + apiKey + ", remitaConsumerToken="+apiHash);

                var response = await _client.HttpAsync(Method.POST,hostUrl,headers,request);
                if (response.IsSuccessful)
                {
                    var result = response.Content;
                    return JsonConvert.DeserializeObject<StopLoanCollectionResponse>(result);
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