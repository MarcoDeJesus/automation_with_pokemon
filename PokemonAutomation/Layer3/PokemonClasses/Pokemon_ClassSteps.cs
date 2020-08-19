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

        [Given(@"that the test user has selects '(.*)' as the test Pokemon")]
        public static void ThatTheTestUserHasSelectsAsTheTestPokemon(string p0)
        {
            if (TestContextData.ContainsKey("TestPokemon"))
            {
                TestContextData.Remove("TestPokemon");
            }
            PokemonFactory TestPokemon = new PokemonFactory(p0.ToLower());
            TestContextData.Add("TestPokemon", TestPokemon);
        }


        [Given(@"that the test user generates a Pokemon instance")]
        public static void TheTestUserGeneratesAnInstance()
        {
            if (TestContextData.ContainsKey("TestInstance"))
            {
                TestContextData.Remove("TestInstance");
            }
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            Pokemon Shiny = new Pokemon(TestPokemon);
            TestContextData.Add("TestInstance", Shiny);
        }


        [When(@"the test user generates an instance using only the IsShiny flag as '(.*)'")]
        public static void TheTestUserGeneratesAnInstanceUsingOnlyTheIsShinyFlagAs(string p0)
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

        [Given(@"that the test user adds '(.*)' EV points to the HP stat")]
        [When(@"the test user adds '(.*)' EV points to the HP stat")]
        public void TheTestUserAddsEVPointsToTheHPStat(int p0)
        {
            Pokemon TestInstance = TestContextData["TestInstance"];
            TestInstance.AddEVPointsToHP(p0);
            if (TestContextData.ContainsKey("TestInstance"))
            {
                TestContextData.Remove("TestInstance");
            }
            TestContextData.Add("TestInstance", TestInstance);
        }

        [When(@"the test user resets the Pokemon EVs")]
        public void WhenTheTestUserResetsThePokemonEVs()
        {
            Pokemon TestInstance = TestContextData["TestInstance"];
            TestInstance.ResetEVs();
            if (TestContextData.ContainsKey("TestInstance"))
            {
                TestContextData.Remove("TestInstance");
            }
            TestContextData.Add("TestInstance", TestInstance);
        }


        [Then(@"HP stat should have '(.*)' EV points")]
        public void ThenHPStatShouldHaveEVPoints(int p0)
        {
            Pokemon TestInstance = TestContextData["TestInstance"];
            int points = TestInstance.EVsHP;
            Assert.True(p0.Equals(points));
        }



        [Then(@"the result Pokemon should '(.*)' be shiny")]
        public static void TheResultPokemonShouldBeShiny(string shiny)
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
