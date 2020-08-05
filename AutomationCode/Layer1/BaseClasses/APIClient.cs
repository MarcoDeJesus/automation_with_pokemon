using System;
using System.Net;
using RestSharp;

namespace APIClients
{
    public class APIClient
    {
        public string RequestPayload;
        public string RequestServerURL;
        public string RequestMethod;
        public string RequestURI;
        public string BearerToken;
        private IRestClient Client;
        private IRestRequest Request;
        private IRestResponse  RequestResponse;

        public void CreateRequest() {
            Uri baseUrl = new Uri(RequestServerURL);
            Client = new RestClient(baseUrl);
            switch (RequestMethod.ToLower())
            {
                case "get":
                    Request = new RestRequest(RequestURI, Method.GET);
                    Request.AddHeader("authorization", "Bearer "+ BearerToken);
                    break;
                case "post":
                    Request = new RestRequest(RequestURI, Method.POST);
                    Request.AddHeader("authorization", "Bearer " + BearerToken);
                    break;
                case "put":
                    Request = new RestRequest(RequestURI, Method.PUT);
                    Request.AddHeader("authorization", "Bearer " + BearerToken);
                    break;
                default:
                    Request = new RestRequest(RequestURI, Method.GET);
                    Request.AddHeader("authorization", "Bearer " + BearerToken);
                    break;
            }
            Request.AddHeader("Accept", "application/json, text/plain, */*");
        }

        public void AddHeaders(string Header, string HeaderValue) {
            Request.AddHeader(Header, HeaderValue);
        }

        public void AddPayload()
        {
            Request.AddParameter("application/json; charset=utf-8", RequestPayload, ParameterType.RequestBody);
        }


        public void ExecuteRequest()
        {
            RequestResponse = Client.Execute(Request);
        }

        public int GetResponseCode() {
            HttpStatusCode statusCode = RequestResponse.StatusCode;
            return (int)statusCode;
        }

        public string GetResponseData() {
            return RequestResponse.Content;
        }


    }
}
