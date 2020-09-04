using Features;
using NUnit.Framework;
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
            if (TestContextData.ContainsKey("TestPokemonName"))
            {
                TestContextData.Remove("TestPokemonName");
            }
            string TestPokemonName = p0.ToLower();
            TestContextData.Add("TestPokemonName", TestPokemonName);
        }


        [Given(@"that the test user gets a test Pokemon")]
        public void ThatTheTestUserGetsATestPokemon()
        {
            string testPokemonName = TestContextData["TestPokemonName"];
            Pokemon TestPokemon = new Pokemon(testPokemonName);
            TestContextData.Add("TestPokemon", TestPokemon);
        }



        [When(@"the test user generates an instance using only the IsShiny flag as '(.*)'")]
        public static void TheTestUserGeneratesAnInstanceUsingOnlyTheIsShinyFlagAs(string p0)
        {
            if (TestContextData.ContainsKey("TestPokemon"))
            {
                TestContextData.Remove("TestPokemon");
            }
            string testPokemonName = TestContextData["TestPokemonName"];
            switch (p0)
            {
                case "enabled":
                    Pokemon Shiny = new Pokemon(testPokemonName, true);
                    TestContextData.Add("TestPokemon", Shiny);
                    break;
                case "disabled":
                    Pokemon NotShiny = new Pokemon(testPokemonName, false);
                    TestContextData.Add("TestPokemon", NotShiny);
                    break;
            }
        }

        [Given(@"that the test user adds '(.*)' EV points to the HP stat")]
        [When(@"the test user adds '(.*)' EV points to the HP stat")]
        public void TheTestUserAddsEVPointsToTheHPStat(int p0)
        {
            Pokemon TestInstance = TestContextData["TestPokemon"];
            TestInstance.AddEVPointsToHP(p0);
            if (TestContextData.ContainsKey("TestPokemon"))
            {
                TestContextData.Remove("TestPokemon");
            }
            TestContextData.Add("TestPokemon", TestInstance);
        }

        [When(@"the test user resets the Pokemon EVs")]
        public void WhenTheTestUserResetsThePokemonEVs()
        {
            Pokemon TestInstance = TestContextData["TestPokemon"];
            TestInstance.ResetEVs();
            if (TestContextData.ContainsKey("TestPokemon"))
            {
                TestContextData.Remove("TestPokemon");
            }
            TestContextData.Add("TestPokemon", TestInstance);
        }


        [Then(@"HP stat should have '(.*)' EV points")]
        public void ThenHPStatShouldHaveEVPoints(int p0)
        {
            Pokemon TestInstance = TestContextData["TestPokemon"];
            int points = TestInstance.EVsHP;
            Assert.True(p0.Equals(points));
        }



        [Then(@"the result Pokemon should '(.*)' be shiny")]
        public static void TheResultPokemonShouldBeShiny(string shiny)
        {
            Pokemon TestInstance = TestContextData["TestPokemon"];
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
