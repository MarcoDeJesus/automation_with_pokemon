using System;
using RestSharp;

namespace APIClients
{
    public class APIClient
    {

        public IRestResponse ExecuteGETCall(string URL, string URI)
        {
            IRestClient Client;
            Uri BaseURL = new Uri(URL);
            Client = new RestClient(BaseURL);
            IRestRequest Request = new RestRequest(URI, Method.GET);
            IRestResponse RequestResponse = Client.Execute(Request);
            return RequestResponse;
        }


        public IRestResponse ExecutePOSTCall(string URL, string URI, string Payload)
        {
            IRestClient Client;
            Uri BaseURL = new Uri(URL);
            Client = new RestClient(BaseURL);
            IRestRequest Request = new RestRequest(URI, Method.POST);
            Request.AddParameter("application/json; charset=utf-8", Payload, ParameterType.RequestBody);
            IRestResponse RequestResponse = Client.Execute(Request);
            return RequestResponse;
        }


        public IRestResponse ExecutePUTCall(string URL, string URI, string Payload)
        {
            IRestClient Client;
            Uri BaseURL = new Uri(URL);
            Client = new RestClient(BaseURL);
            IRestRequest Request = new RestRequest(URI, Method.PUT);
            Request.AddParameter("application/json; charset=utf-8", Payload, ParameterType.RequestBody);
            IRestResponse RequestResponse = Client.Execute(Request);
            return RequestResponse;
        }


    }
}
