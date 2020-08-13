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

            IRestResponse Response2 = PokEndObj.RetrievePokemonInformation(150);
            int statusCode2 = (int)Response2.StatusCode;
            string response2 = Response2.Content;
            Console.WriteLine(statusCode2);
            Console.WriteLine(response2);

        }
    }
}
