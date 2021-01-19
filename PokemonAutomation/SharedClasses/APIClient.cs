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
