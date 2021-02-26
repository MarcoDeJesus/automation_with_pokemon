using System;
using System.Net;
using RestSharp;

namespace APIClients
{
    public class APIClient
    {
        public string targetURI { get; private set; } = null;
        private IRestClient _clientAPI;
        private IRestRequest _request;
        private bool _requestReady = false;



        public APIClient(string url, string uri)
        {
            Uri urlObj = new Uri(url);
            targetURI = uri;
            IRestClient client = new RestClient(urlObj);
            _clientAPI = client;
        }


        public APIClient(string url, string uri, string method)
        {
            Uri urlObj = new Uri(url);
            targetURI = uri;
            IRestClient client = new RestClient(urlObj);
            _clientAPI = client;
            switch (method.ToLower())
            {
                case "get":
                    CreateGETRequest();
                    break;
                case "post":
                    CreatePOSTRequest();
                    break;
                case "put":
                    CreatePUTRequest();
                    break;
                case "delete":
                    CreateDELETERequest();
                    break;
                default:
                    CreateGETRequest();
                    break;
            }
        }


        public void CreateGETRequest()
        {
            IRestRequest request = new RestRequest(targetURI, Method.GET);
            _request = request;
            _requestReady = true;
        }

        public void CreatePOSTRequest()
        {
            IRestRequest request = new RestRequest(targetURI, Method.POST);
            _request = request;
            _requestReady = true;
        }


        public void CreatePUTRequest()
        {
            IRestRequest request = new RestRequest(targetURI, Method.PUT);
            _request = request;
            _requestReady = true;
        }


        public void CreateDELETERequest()
        {
            IRestRequest request = new RestRequest(targetURI, Method.DELETE);
            _request = request;
            _requestReady = true;
        }

        public void AddHeaderToRequest(string key, string value)
        {
            if (_requestReady)
            {
                _request.AddHeader(key, value);
            }
        }

        public void AddJSONPayloadToRequest(string payload)
        {
            if (_requestReady)
            {
                _request.AddParameter("application/json; charset=utf-8", payload, ParameterType.RequestBody);
            }
        }

        public void AddBearerTokenToRequest(string token)
        {
            if (_requestReady)
            {
                _request.AddHeader("authorization", "Bearer " + token);
            }
        }

        public IRestResponse ExecuteAPICall()
        {
            IRestResponse response = _clientAPI.Execute(_request);
            return response;
        }

    }
}
