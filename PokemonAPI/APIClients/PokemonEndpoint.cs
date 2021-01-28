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
            APIClient APIClientObject = new APIClient();
            IRestResponse ResponseObject = APIClientObject.ExecuteGETCall(URL, URI);
            return ResponseObject;
        }

        public IRestResponse RetrievePokemonInformation(int PokemonNumber)
        {
            string URI = "api/v2/pokemon/" + PokemonNumber.ToString();
            APIClient APIClientObject = new APIClient();
            IRestResponse ResponseObject = APIClientObject.ExecuteGETCall(URL, URI);
            return ResponseObject;
        }

    }
}
