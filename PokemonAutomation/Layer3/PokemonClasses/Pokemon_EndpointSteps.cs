using NUnit.Framework;
using Features;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsSteps
{
    [Binding]
    public class Pokemon_EndpointSteps
    {

        [Given(@"that the user has selected the '(.*)' Pokemon")]
        public static void GivenThatTheUserHasSelectedThePokemon(string p0)
        {
            if (GenericSteps.TestContextData.ContainsKey("PokemonName"))
            {
                GenericSteps.TestContextData.Remove("PokemonName");
            }
            p0 = p0.ToLower();
            GenericSteps.TestContextData.Add("PokemonName", p0);
        }
        
        [When(@"the test user queries the Pokemon API with the selected Pokemon")]
        public static void WhenTheTestUserQueriesThePokemonAPIWithTheSelectedPokemon()
        {
            if (GenericSteps.TestContextData.ContainsKey("TestPokemon"))
            {
                GenericSteps.TestContextData.Remove("TestPokemon");
            }
            string PokemonName = GenericSteps.TestContextData["PokemonName"];
            PokemonFactory TestPokemon = new PokemonFactory(PokemonName);
            GenericSteps.TestContextData.Add("TestPokemon", TestPokemon);
        }


        [Then(@"The API response should include the name of the provided Pokemon")]
        public static void ThenTheAPIResponseShouldIncludeTheNameOfTheProvidedPokemon()
        {
            PokemonFactory TestPokemon = GenericSteps.TestContextData["TestPokemon"];
            string PokemonName = GenericSteps.TestContextData["PokemonName"];
            Assert.True(TestPokemon.Name.ToLower().Equals(PokemonName));
        }


        [Then(@"The API response should return the pokemon number as '(.*)'")]
        public static void ThenTheAPIResponseShouldReturnThePokemonNumberAs(string poknumber)
        {
            PokemonFactory TestPokemon = GenericSteps.TestContextData["TestPokemon"];
            Assert.True(TestPokemon.Number.ToString().Equals(poknumber));
        }

        [Then(@"The API response should return the pokemon Base HP as as '(.*)'")]
        public static void ThenTheAPIResponseShouldReturnThePokemonBaseHPAsAs(string p0)
        {
            PokemonFactory TestPokemon = GenericSteps.TestContextData["TestPokemon"];
            Assert.True(TestPokemon.BaseHP.ToString().Equals(p0));
        }

        [Then(@"The API response should return the pokemon Base Attack as as '(.*)'")]
        public static void ThenTheAPIResponseShouldReturnThePokemonBaseAttackAsAs(string p0)
        {
            PokemonFactory TestPokemon = GenericSteps.TestContextData["TestPokemon"];
            Assert.True(TestPokemon.BaseAttack.ToString().Equals(p0));
        }

        [Then(@"The API response should return the pokemon Base Defense as as '(.*)'")]
        public static void ThenTheAPIResponseShouldReturnThePokemonBaseDefenseAsAs(string p0)
        {
            PokemonFactory TestPokemon = GenericSteps.TestContextData["TestPokemon"];
            Assert.True(TestPokemon.BaseDefense.ToString().Equals(p0));
        }

        [Then(@"The API response should return the pokemon Base Special Attack as as '(.*)'")]
        public static void ThenTheAPIResponseShouldReturnThePokemonBaseSpecialAttackAsAs(string p0)
        {
            PokemonFactory TestPokemon = GenericSteps.TestContextData["TestPokemon"];
            Assert.True(TestPokemon.BaseSpecialAttack.ToString().Equals(p0));
        }

        [Then(@"The API response should return the pokemon Base Special Defense as as '(.*)'")]
        public static void ThenTheAPIResponseShouldReturnThePokemonBaseSpecialDefenseAsAs(string p0)
        {
            PokemonFactory TestPokemon = GenericSteps.TestContextData["TestPokemon"];
            Assert.True(TestPokemon.BaseSpecialDefense.ToString().Equals(p0));
        }


        [Then(@"The API response should return the pokemon Base Speed as as '(.*)'")]
        public static void ThenTheAPIResponseShouldReturnThePokemonBaseSpeedAsAs(string p0)
        {
            PokemonFactory TestPokemon = GenericSteps.TestContextData["TestPokemon"];
            Assert.True(TestPokemon.BaseSpeed.ToString().Equals(p0));
        }
    }
}
