using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Models.GetBillers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace Infrastructure.Services
{
    public class BillerAggregationService : IBillerAggregationService
    {
        private readonly IHttpCommunication _client;
        private readonly ILogger<BillerAggregationService> _logger;
        private readonly IConfiguration _config;

        public BillerAggregationService(IConfiguration config, ILogger<BillerAggregationService> logger, IHttpCommunication client)
        {
            _config = config;
            _logger = logger;
            _client = client;
        }

        public async Task<GetBillersResponse> GetBillers()
        {
            try
            {
                 var hostUrl = $"{_config["Biller_baseUrl"]}/billers";
                 var headers = new Dictionary<string,string>();
                 headers.Add("Content-Type", "application/json");
                 headers.Add("publicKey", $"{_config["publicKey"]}");
                 var response = await _client.HttpAsync(Method.GET,hostUrl,headers,null);
                 if (response.IsSuccessful)
                 {
                     var result = response.Content;
                     return JsonConvert.DeserializeObject<GetBillersResponse>(result);
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