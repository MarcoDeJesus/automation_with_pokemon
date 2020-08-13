﻿using RestSharp;

namespace APIClients
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
    }
}
