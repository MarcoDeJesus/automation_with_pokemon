using APIClients;
using RestSharp;

namespace PokemonAPI
{
    class PokemonEndpoint
    {
        public string URL;


        public PokemonEndpoint(string APIURL)
        {
            URL = APIURL;
        }

        public IRestResponse RetrievePokemonInformation(string PokemonName)
        {
            string URI = "api/v2/pokemon/"+PokemonName.ToLower();
            APIClient aPIClientObject = new APIClient(URL, URI, "get");
            aPIClientObject.AddHeaderToRequest("Accept", "application/json, text/plain, */*");
            IRestResponse ResponseObject = aPIClientObject.ExecuteAPICall();
            return ResponseObject;
        }

        public IRestResponse RetrievePokemonInformation(int PokemonNumber)
        {
            string URI = "api/v2/pokemon/" + PokemonNumber.ToString();
            APIClient aPIClientObject = new APIClient(URL, URI, "get");
            aPIClientObject.AddHeaderToRequest("Accept", "application/json, text/plain, */*");
            IRestResponse ResponseObject = aPIClientObject.ExecuteAPICall();
            return ResponseObject;
        }

    }
}
