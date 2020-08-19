using APIModules;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace PokemonAutomation.Layer3.PokemonClasses
{
    [Binding]
    public class Pokemon_ClassSteps
    {
        public static Dictionary<string, dynamic> TestContextData = new Dictionary<string, dynamic>();

        [Given(@"the test user has selects '(.*)' as the test Pokemon")]
        public static void GivenTheTestUserHasSelectsAsTheTestPokemon(string p0)
        {
            if (TestContextData.ContainsKey("TestPokemon"))
            {
                TestContextData.Remove("TestPokemon");
            }
            PokemonFactory TestPokemon = new PokemonFactory(p0.ToLower());
            TestContextData.Add("TestPokemon", TestPokemon);
        }
        

        [When(@"the test user generates an instance using only the IsShiny flag as '(.*)'")]
        public static void WhenTheTestUserGeneratesAnInstanceUsingOnlyTheIsShinyFlagAs(string p0)
        {
            if (TestContextData.ContainsKey("TestInstance"))
            {
                TestContextData.Remove("TestInstance");
            }
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            switch (p0)
            {
                case "enabled":
                    Pokemon Shiny = new Pokemon(TestPokemon, true);
                    TestContextData.Add("TestInstance", Shiny);
                    break;
                case "disabled":
                    Pokemon NotShiny = new Pokemon(TestPokemon, false);
                    TestContextData.Add("TestInstance", NotShiny);
                    break;
            }
        }
        
        [Then(@"the result Pokemon should '(.*)' be shiny")]
        public static void ThenTheResultPokemonShouldBeShiny(string shiny)
        {
            Pokemon TestInstance = TestContextData["TestInstance"];
            bool IsShiny = TestInstance.IsShiny;
            switch (shiny)
            {
                case "yes":
                    Assert.True(true.Equals(IsShiny));
                    break;
                case "no":
                    Assert.True(false.Equals(IsShiny));
                    break;
            }
        }
    }
}
