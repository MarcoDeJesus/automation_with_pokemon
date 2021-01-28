using PokemonAPI;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAPIFeature
{
    public class PokemonEndpointFeature
    {
     

        public IRestResponse GetDataFromPokemonNumber(int pokemonNumber)
        {
            string APIURL = "https://pokeapi.co/";
            PokemonEndpoint PokEndObj = new PokemonEndpoint(APIURL);
            IRestResponse response = PokEndObj.RetrievePokemonInformation(pokemonNumber);
            return response;
        }

        public IRestResponse GetDataFromPokemonNamed(string pokemonName)
        {
            string APIURL = "https://pokeapi.co/";
            PokemonEndpoint PokEndObj = new PokemonEndpoint(APIURL);
            IRestResponse response = PokEndObj.RetrievePokemonInformation(pokemonName);
            return response;
        }
    }
}
