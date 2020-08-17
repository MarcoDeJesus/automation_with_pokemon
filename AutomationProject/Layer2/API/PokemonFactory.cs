using PokemonTypesNamespace;
using APIClients;
using RestSharp;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using PokemonClasses;

namespace APIModules
{
    class PokemonFactory
    {
        public int Number;
        public string Name;
        public List<PokemonTypes> PokemonTypes = new List<PokemonTypes>();
        public List<PokemonAbility> PokemonAbilities = new List<PokemonAbility>();
        public int BaseHP;
        public int BaseAttack;
        public int BaseDefense;
        public int BaseSpecialAttack;
        public int BaseSpecialDefense;
        public int BaseSpeed;
        public IRestResponse RequestResponse;

        public PokemonFactory(int pokemonNumber)
        {
            string APIURL = "https://pokeapi.co/";
            PokemonEndpoint PokEndObj = new PokemonEndpoint(APIURL);
            RequestResponse = PokEndObj.RetrievePokemonInformation(pokemonNumber);
            dynamic PokemonData;
            if ((int)RequestResponse.StatusCode == 200)
            {
                PokemonData = JsonConvert.DeserializeObject(RequestResponse.Content);
                SetPokemonData(PokemonData);
            }

        }

        public PokemonFactory(string pokemonName)
        {
            string APIURL = "https://pokeapi.co/";
            PokemonEndpoint PokEndObj = new PokemonEndpoint(APIURL);
            RequestResponse = PokEndObj.RetrievePokemonInformation(pokemonName.ToLower());
            dynamic PokemonData;
            if ((int)RequestResponse.StatusCode == 200)
            {
                PokemonData = JsonConvert.DeserializeObject(RequestResponse.Content);
                SetPokemonData(PokemonData);
            }
        }

        private void SetPokemonData(dynamic data)
        {
            List<PokemonTypes> ThisPokemonTypes = new List<PokemonTypes>();
            int CountTypes = data["types"].Count;
            for (int i = 0; i <= CountTypes - 1; i++)
            {
                PokemonTypes TypePokemon = new PokemonTypes();
                TypePokemon.TypeSlot = data["types"][i]["slot"];
                TypePokemon.TypeName = data["types"][i]["type"]["name"];
                ThisPokemonTypes.Add(TypePokemon);
            }
            List<PokemonAbility> ThisPokemonAbilities = new List<PokemonAbility>();
            int CountAbilities = data["abilities"].Count;
            for (int i = 0; i <= CountAbilities - 1; i++)
            {
                PokemonAbility AbilityPokemon = new PokemonAbility();
                AbilityPokemon.AbilitySlot = data["abilities"][i]["slot"];
                AbilityPokemon.AbilityName = data["abilities"][i]["ability"]["name"];
                AbilityPokemon.IsHiddenAbility = data["abilities"][i]["is_hidden"];
                ThisPokemonAbilities.Add(AbilityPokemon);
            }
            PokemonTypes = ThisPokemonTypes;
            PokemonAbilities = ThisPokemonAbilities;
            Name = data["species"]["name"];
            Number = data["id"];
            BaseHP = data["stats"][0]["base_stat"];
            BaseAttack = data["stats"][1]["base_stat"];
            BaseDefense = data["stats"][2]["base_stat"];
            BaseSpecialAttack = data["stats"][3]["base_stat"];
            BaseSpecialDefense = data["stats"][4]["base_stat"];
            BaseSpeed = data["stats"][5]["base_stat"];
        }

        public PokemonTypes GetThisPokemonPrimaryType()
        {
            PokemonTypes ThisType = new PokemonTypes();
            foreach (PokemonTypes pkt in PokemonTypes)
            {
                if (pkt.TypeSlot == 1)
                {
                    ThisType = pkt;
                    break;
                }
            }
            return ThisType;
        }


        public bool ThisPokemonHasASecondType()
        {
            bool hasSecond = false;
            foreach (PokemonTypes pkt in PokemonTypes)
            {
                if (pkt.TypeSlot == 2)
                {
                    hasSecond = true;
                    break;
                }
            }
            return hasSecond;
        }

        public PokemonTypes GetThisPokemonSecondaryType()
        {
            PokemonTypes ThisType = new PokemonTypes();
            foreach (PokemonTypes pkt in PokemonTypes)
            {
                if (pkt.TypeSlot == 2)
                {
                    ThisType = pkt;
                    break;
                }
            }
            return ThisType;
        }


    }

}
