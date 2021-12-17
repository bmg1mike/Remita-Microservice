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
    }
}