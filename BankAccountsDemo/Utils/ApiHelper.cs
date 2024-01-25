using RestSharp;
using Newtonsoft.Json;
using BankAccountsDemo.Models;

namespace BankAccountsDemo.Util
{
    public class ApiHelper
    {
        private static RestClient client = new RestClient("https://localhost:8080/api");

        public static RestResponse ExecutePostRequest<T>(string url, T requestBody)
        {
            RestRequest request = new RestRequest(url, Method.Post);
            string addBody = SerializeRequestBody(requestBody);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", addBody, ParameterType.RequestBody);

            return client.Execute(request);
        }

        public static RestResponse ExecuteGetRequest<T>(string url, T requestBody)
        {
            RestRequest request = new RestRequest(url, Method.Get);
            string addBody = SerializeRequestBody(requestBody);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", addBody, ParameterType.RequestBody);
            return client.Execute(request);
        }

        public static T DeserializeResponse<T>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public static RestResponse ExecuteDeleteRequest(string url)
        {
            var request = new RestRequest(url, Method.Delete);
            return client.Execute(request);
        }

        public static RestResponse ExecutePutRequest<T>(string url, T requestBody)
        {
            var request = new RestRequest(url, Method.Put);
            string addBody = SerializeRequestBody(requestBody);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", addBody, ParameterType.RequestBody);

            return client.Execute(request);
        }

        public static string SerializeRequestBody<T>(T requestBody)
        {
            return JsonConvert.SerializeObject(requestBody);
        }
    }
}