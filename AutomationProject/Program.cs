using System;
using System.Net;
using APIClients;
using RestSharp;

namespace AutomationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string APIURL = "https://pokeapi.co/";
            PokemonEndpoint PokEndObj = new PokemonEndpoint(APIURL);
            IRestResponse Response = PokEndObj.RetrievePokemonInformation("PIKACHU");
            int statusCode = (int)Response.StatusCode;
            string response = Response.Content;
            Console.WriteLine(statusCode);
            Console.WriteLine(response);

        }
    }
}
