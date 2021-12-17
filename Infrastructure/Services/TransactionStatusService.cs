using Domain.Models;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;
using Infrastructure.Helpers;
using Newtonsoft.Json;
using RestSharp;
using Domain.Interfaces.Services;

namespace Infrastructure.Services
{

    public class TransactionStatusService :ITransactionStatusService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<TransactionStatusService> _logger;
        private readonly IHttpCommunication _client;

        public TransactionStatusService(IConfiguration config, ILogger<TransactionStatusService> logger, IHttpCommunication client)
        {
            _config = config;
            _logger = logger;
            _client = client;
        }

        public async Task<TransactionStatusResponse> CheckTransactionStatus(string transactionId)
        {
            try
            {
                    var hash = Hashing.HashSha512Data($"{transactionId}{_config["Remita:CheckoutSolution:secretKey"]}");
                    var hostUrl = $"{_config["Remita:CheckoutSolution:BaseUrl"]}/{transactionId}";
                    var headers = new Dictionary<string,string>();
                    headers.Add("publicKey", $"{_config["Remita:CheckoutSolution:publicKey"]}");
                    headers.Add("Content-Type", "application/json");
                    headers.Add("TXN_HASH", $"{hash}");
                    var response = await _client.HttpAsync(Method.GET,hostUrl,headers,null);
                    if (response.IsSuccessful)
                    {
                        var result = response.Content;
                        return JsonConvert.DeserializeObject<TransactionStatusResponse>(result);
                    }

                    return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<TransactionResponse> CheckTransactionStatusByOrderId(string orderId)
        {
            try
            {
                var merchantId = _config["Remita:CheckoutSolution:merchantId"];
                var apiKey = _config["Remita:CheckoutSolution:apiKey"];
                var apiHash = Hashing.HashSha512Data($"{orderId}{apiKey}{merchantId}");
                var authorization = $"remitaConsumerKey={merchantId},remitaConsumerToken={apiHash}";
                var hostUrl = $"https://remitademo.net/remita/exapp/api/v1/send/api/echannelsvc/{merchantId}/{orderId}/{apiHash}/orderstatus.reg";
                var headers = new Dictionary<string,string>();
                headers.Add("Content-Type", "application/json");
                headers.Add("Authorization",authorization);
                var response = await _client.HttpAsync(Method.GET,hostUrl,headers,null);

                if (response.IsSuccessful)
                {
                    var result = response.Content;
                    return JsonConvert.DeserializeObject<TransactionResponse>(result);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<TransactionResponse> CheckTransactionStatusByRRR(string rrr)
        {
            try
            {
                var merchantId = _config["Remita:CheckoutSolution:merchantId"];
                var apiKey = _config["Remita:CheckoutSolution:apiKey"];
                var apiHash = Hashing.HashSha512Data($"{rrr}{apiKey}{merchantId}");
                var authorization = $"remitaConsumerKey={merchantId},remitaConsumerToken={apiHash}";
                var hostUrl = $"https://remitademo.net/remita/exapp/api/v1/send/api/echannelsvc/{merchantId}/{rrr}/{apiHash}/orderstatus.reg";
                var headers = new Dictionary<string,string>();
                headers.Add("Content-Type", "application/json");
                headers.Add("Authorization",authorization);

                var response = await _client.HttpAsync(Method.GET,hostUrl,headers,null);

                if (response.IsSuccessful)
                {
                    var result = response.Content;
                    return JsonConvert.DeserializeObject<TransactionResponse>(result);
                }

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