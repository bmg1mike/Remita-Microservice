using RestSharp;

namespace Domain.Interfaces
{
    public interface IHttpCommunication
    {
        Task<IRestResponse> HttpAsync(Method httpVerb, string hostUrl, Dictionary<string, string> headers, object requestObject);
    }
}