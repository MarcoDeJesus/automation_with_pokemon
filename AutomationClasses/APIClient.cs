using System;
using System.Net;
using RestSharp;

namespace APIClients
{
    public class APIClient
    {
        public string targetURL = null;
        public string targetURI = null;
        private Uri _uriObject;
        private IRestClient _clientAPI;
        private IRestRequest _request;


        public APIClient(string url)
        {
            targetURL = url;
            Uri urlObj = new Uri(targetURL);
            _uriObject = urlObj;
        }


        public void SetThisURI(string uri)
        {
            targetURI = uri;
            IRestClient client = new RestClient(_uriObject);
            _clientAPI = client;
        }

        public void CreateGETRequest()
        {
            IRestRequest request = new RestRequest(targetURI, Method.GET);
            _request = request;
        }

        public void CreatePOSTRequest()
        {
            IRestRequest request = new RestRequest(targetURI, Method.POST);
            _request = request;
        }


        public void CreatePUTRequest()
        {
            IRestRequest request = new RestRequest(targetURI, Method.PUT);
            _request = request;
        }


        public void CreateDELETERequest()
        {
            IRestRequest request = new RestRequest(targetURI, Method.DELETE);
            _request = request;
        }

        public void AddHeaderToRequest(string key, string value)
        {
            _request.AddHeader(key, value);
        }

        public void AddJSONPayloadToRequest(string payload)
        {

            _request.AddParameter("application/json; charset=utf-8", payload, ParameterType.RequestBody);
        }

        public void AddBearerTokenToRequest(string token)
        {
            _request.AddHeader("authorization", "Bearer " + token);
        }

        public IRestResponse ExecuteAPICall()
        {
            IRestResponse response = _clientAPI.Execute(_request);
            return response;
        }

    }
}
