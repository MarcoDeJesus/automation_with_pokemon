using PokemonTypesNamespace;
using APIClients;
using RestSharp;

namespace PokemonClasses
{
    public class PokemonTemplate
    {
        private int Number;
        private string Name;
        private string Type1;
        private string Type2;
        private string Ability1;
        private string Ability2;
        private string HiddenAbility;
        private int BaseHP;
        private int BaseAttack;
        private int BaseDefense;
        private int BaseSpecialAttack;
        private int BaseSpecialDefense;
        private int BaseSpeed;

        public PokemonTemplate(int pokemonNumber)
        {
            string APIURL = "https://pokeapi.co/";
            PokemonEndpoint PokEndObj = new PokemonEndpoint(APIURL);
            IRestResponse Response = PokEndObj.RetrievePokemonInformation(pokemonNumber);
        }

        public PokemonTemplate(string pokemonName)
        {
            string APIURL = "https://pokeapi.co/";
            PokemonEndpoint PokEndObj = new PokemonEndpoint(APIURL);
            IRestResponse Response = PokEndObj.RetrievePokemonInformation(pokemonName.ToLower());
        }

    }

}
