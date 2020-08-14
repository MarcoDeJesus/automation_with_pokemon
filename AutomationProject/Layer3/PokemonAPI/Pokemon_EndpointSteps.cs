﻿using NUnit.Framework;
using PokemonClasses;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace AutomationProject.Layer3.PokemonAPI
{
    [Binding]
    public class Pokemon_EndpointSteps
    {
        Dictionary<string, dynamic> TestContextData = new Dictionary<string, dynamic>();

        [Given(@"that the user has selected the '(.*)' Pokemon")]
        public void GivenThatTheUserHasSelectedThePokemon(string p0)
        {
            if (TestContextData.ContainsKey("PokemonName"))
            {
                TestContextData.Remove("PokemonName");
            }
            p0 = p0.ToLower();
            TestContextData.Add("PokemonName", p0);
        }
        
        [When(@"the test user queries the Pokemon API with the selected Pokemon")]
        public void WhenTheTestUserQueriesThePokemonAPIWithTheSelectedPokemon()
        {
            if (TestContextData.ContainsKey("TestPokemon"))
            {
                TestContextData.Remove("TestPokemon");
            }
            string PokemonName = TestContextData["PokemonName"];
            PokemonFactory TestPokemon = new PokemonFactory(PokemonName);
            TestContextData.Add("TestPokemon", TestPokemon);
        }


        [Then(@"The API response should include the name of the provided Pokemon")]
        public void ThenTheAPIResponseShouldIncludeTheNameOfTheProvidedPokemon()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            string PokemonName = TestContextData["PokemonName"];
            Assert.True(TestPokemon.Name.ToLower().Equals(PokemonName));
        }


        [Then(@"The API response should return the pokemon number as '(.*)'")]
        public void ThenTheAPIResponseShouldReturnThePokemonNumberAs(string poknumber)
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            Assert.True(TestPokemon.Number.ToString().Equals(poknumber));
        }

        [Then(@"The API response should return the pokemon Base HP as as '(.*)'")]
        public void ThenTheAPIResponseShouldReturnThePokemonBaseHPAsAs(string p0)
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            Assert.True(TestPokemon.BaseHP.ToString().Equals(p0));
        }

        [Then(@"The API response should return the pokemon Base Attack as as '(.*)'")]
        public void ThenTheAPIResponseShouldReturnThePokemonBaseAttackAsAs(string p0)
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            Assert.True(TestPokemon.BaseAttack.ToString().Equals(p0));
        }

        [Then(@"The API response should return the pokemon Base Defense as as '(.*)'")]
        public void ThenTheAPIResponseShouldReturnThePokemonBaseDefenseAsAs(string p0)
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            Assert.True(TestPokemon.BaseDefense.ToString().Equals(p0));
        }

        [Then(@"The API response should return the pokemon Base Special Attack as as '(.*)'")]
        public void ThenTheAPIResponseShouldReturnThePokemonBaseSpecialAttackAsAs(string p0)
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            Assert.True(TestPokemon.BaseSpecialAttack.ToString().Equals(p0));
        }

        [Then(@"The API response should return the pokemon Base Special Defense as as '(.*)'")]
        public void ThenTheAPIResponseShouldReturnThePokemonBaseSpecialDefenseAsAs(string p0)
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            Assert.True(TestPokemon.BaseSpecialDefense.ToString().Equals(p0));
        }


        [Then(@"The API response should return the pokemon Base Speed as as '(.*)'")]
        public void ThenTheAPIResponseShouldReturnThePokemonBaseSpeedAsAs(string p0)
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            Assert.True(TestPokemon.BaseSpeed.ToString().Equals(p0));
        }
    }
}