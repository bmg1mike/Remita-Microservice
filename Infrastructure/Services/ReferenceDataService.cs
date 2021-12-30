using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Models.AvailableRefData;
using Domain.Models.GetServicesByRefId;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace Infrastructure.Services
{
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly IHttpCommunication _client;
        private readonly ILogger<ReferenceDataService> _logger;
        private readonly IConfiguration _config;

        public ReferenceDataService(IConfiguration config, ILogger<ReferenceDataService> logger, IHttpCommunication client)
        {
            _config = config;
            _logger = logger;
            _client = client;
        }

        public async Task<AvailableRefDataResponse> AvailableRefData()
        {
            try
            {
                 var hostUrl = "https://remitademo.net/remita/ecomm/send/api/availablereferencedata";
                 var publicKey = _config["Public_Key"];
                 var headers = new Dictionary<string,string>();
                 headers.Add("Content-Type", "application/json");
                 headers.Add("X-API-PUBLIC-KEY",$"{publicKey}");
                var response = await _client.HttpAsync(Method.GET,hostUrl,headers,null);

                if (response.IsSuccessful)
                {
                    var result = response.Content;
                    return JsonConvert.DeserializeObject<AvailableRefDataResponse>(result);
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

        public async Task<ServicesByRefIdResponse> GetServicesByRefId(string refId)
        {
            try
            {
                 var hostUrl = $"https://remitademo.net/remita/ecomm/send/api/reference-data-configs/{refId}";
                 var publicKey = _config["Public_Key"];
                 var headers = new Dictionary<string,string>();
                 headers.Add("Content-Type", "application/json");
                 headers.Add("X-API-PUBLIC-KEY",$"{publicKey}");

                 var response = await _client.HttpAsync(Method.GET,hostUrl,headers,null);

                if (response.IsSuccessful)
                {
                    var result = response.Content;
                    return JsonConvert.DeserializeObject<ServicesByRefIdResponse>(result);
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