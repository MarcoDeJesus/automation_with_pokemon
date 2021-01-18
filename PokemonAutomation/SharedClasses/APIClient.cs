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
        private IRestClient ClientOld;
        private IRestRequest RequestOld;
        private IRestResponse RequestResponseOld;

        public APIClient()
        {
        }

        public APIClient(string txtoken)
        {
            BearerToken = txtoken;
        }

        public void CreateRequest() {
            Uri baseUrl = new Uri(RequestServerURL);
            ClientOld = new RestClient(baseUrl);
            switch (RequestMethod.ToLower())
            {
                case "get":
                    RequestOld = new RestRequest(RequestURI, Method.GET);
                    RequestOld.AddHeader("authorization", "Bearer "+ BearerToken);
                    break;
                case "post":
                    RequestOld = new RestRequest(RequestURI, Method.POST);
                    RequestOld.AddHeader("authorization", "Bearer " + BearerToken);
                    break;
                case "put":
                    RequestOld = new RestRequest(RequestURI, Method.PUT);
                    RequestOld.AddHeader("authorization", "Bearer " + BearerToken);
                    break;
                default:
                    RequestOld = new RestRequest(RequestURI, Method.GET);
                    RequestOld.AddHeader("authorization", "Bearer " + BearerToken);
                    break;
            }
            RequestOld.AddHeader("Accept", "application/json, text/plain, */*");
        }

        public void AddHeaders(string Header, string HeaderValue) {
            RequestOld.AddHeader(Header, HeaderValue);
        }

        public void AddPayload()
        {
            RequestOld.AddParameter("application/json; charset=utf-8", RequestPayload, ParameterType.RequestBody);
        }


        public void ExecuteRequest()
        {
            RequestResponseOld = ClientOld.Execute(RequestOld);
        }

        public int GetResponseCode() {
            HttpStatusCode statusCode = RequestResponseOld.StatusCode;
            return (int)statusCode;
        }

        public string GetResponseData() {
            return RequestResponseOld.Content;
        }

        public IRestResponse ExecuteGETCall(string URL, string URI)
        {
            IRestClient Client;
            Uri BaseURL = new Uri(URL);
            Client = new RestClient(BaseURL);
            IRestRequest Request = new RestRequest(URI, Method.GET);
            Request.AddHeader("authorization", "Bearer " + BearerToken);
            Request.AddHeader("Accept", "application/json, text/plain, */*");
            IRestResponse RequestResponse = Client.Execute(Request);
            return RequestResponse;
        }


        public IRestResponse ExecutePOSTCall(string URL, string URI, string Payload)
        {
            IRestClient Client;
            Uri BaseURL = new Uri(URL);
            Client = new RestClient(BaseURL);
            IRestRequest Request = new RestRequest(URI, Method.POST);
            Request.AddHeader("authorization", "Bearer " + BearerToken);
            Request.AddParameter("application/json; charset=utf-8", Payload, ParameterType.RequestBody);
            Request.AddHeader("Accept", "application/json, text/plain, */*");
            IRestResponse RequestResponse = Client.Execute(Request);
            return RequestResponse;
        }


        public IRestResponse ExecutePOSTCallNoAuthentication(string URL, string URI, string Payload)
        {
            IRestClient Client;
            Uri BaseURL = new Uri(URL);
            Client = new RestClient(BaseURL);
            IRestRequest Request = new RestRequest(URI, Method.POST);
            Request.AddParameter("application/json; charset=utf-8", Payload, ParameterType.RequestBody);
            Request.AddHeader("Accept", "application/json, text/plain, */*");
            IRestResponse RequestResponse = Client.Execute(Request);
            return RequestResponse;
        }


        public IRestResponse ExecutePOSTCallFromRawRequest(string URL, IRestRequest draftRequest)
        {
            IRestClient Client;
            Uri BaseURL = new Uri(URL);
            Client = new RestClient(BaseURL);
            IRestRequest request = draftRequest;
            IRestResponse RequestResponse = Client.Execute(request);
            return RequestResponse;
        }


        public IRestResponse ExecutePUTCall(string URL, string URI, string Payload)
        {
            IRestClient Client;
            Uri BaseURL = new Uri(URL);
            Client = new RestClient(BaseURL);
            IRestRequest Request = new RestRequest(URI, Method.PUT);
            Request.AddHeader("authorization", "Bearer " + BearerToken);
            Request.AddParameter("application/json; charset=utf-8", Payload, ParameterType.RequestBody);
            Request.AddHeader("Accept", "application/json, text/plain, */*");
            IRestResponse RequestResponse = Client.Execute(Request);
            return RequestResponse;
        }

        public IRestResponse ExecuteDELETECall(string URL, string URI)
        {
            IRestClient Client;
            Uri BaseURL = new Uri(URL);
            Client = new RestClient(BaseURL);
            IRestRequest Request = new RestRequest(URI, Method.DELETE);
            Request.AddHeader("authorization", "Bearer " + BearerToken);
            Request.AddHeader("Accept", "application/json, text/plain, */*");
            IRestResponse RequestResponse = Client.Execute(Request);
            return RequestResponse;
        }

    }
}
