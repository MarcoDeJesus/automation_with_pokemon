using Features;
using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsSteps
{
    [Binding]
    public class Pokemon_ClassSteps
    {

        [Given(@"that the test user has selects '(.*)' as the test Pokemon")]
        public static void ThatTheTestUserHasSelectsAsTheTestPokemon(string p0)
        {
            if (GenericSteps.TestContextData.ContainsKey("TestPokemonName"))
            {
                GenericSteps.TestContextData.Remove("TestPokemonName");
            }
            string TestPokemonName = p0.ToLower();
            GenericSteps.TestContextData.Add("TestPokemonName", TestPokemonName);
        }


        [Given(@"that the test user gets a test Pokemon")]
        public void ThatTheTestUserGetsATestPokemon()
        {
            string testPokemonName = GenericSteps.TestContextData["TestPokemonName"];
            Pokemon TestPokemon = new Pokemon(testPokemonName);
            GenericSteps.TestContextData.Add("TestPokemon", TestPokemon);
        }



        [When(@"the test user generates an instance using only the IsShiny flag as '(.*)'")]
        public static void TheTestUserGeneratesAnInstanceUsingOnlyTheIsShinyFlagAs(string p0)
        {
            if (GenericSteps.TestContextData.ContainsKey("TestPokemon"))
            {
                GenericSteps.TestContextData.Remove("TestPokemon");
            }
            string testPokemonName = GenericSteps.TestContextData["TestPokemonName"];
            switch (p0)
            {
                case "enabled":
                    Pokemon Shiny = new Pokemon(testPokemonName, true);
                    GenericSteps.TestContextData.Add("TestPokemon", Shiny);
                    break;
                case "disabled":
                    Pokemon NotShiny = new Pokemon(testPokemonName, false);
                    GenericSteps.TestContextData.Add("TestPokemon", NotShiny);
                    break;
            }
        }

        [Given(@"that the test user adds '(.*)' EV points to the HP stat")]
        [When(@"the test user adds '(.*)' EV points to the HP stat")]
        public void TheTestUserAddsEVPointsToTheHPStat(int p0)
        {
            Pokemon TestInstance = GenericSteps.TestContextData["TestPokemon"];
            TestInstance.AddEVPointsToHP(p0);
            if (GenericSteps.TestContextData.ContainsKey("TestPokemon"))
            {
                GenericSteps.TestContextData.Remove("TestPokemon");
            }
            GenericSteps.TestContextData.Add("TestPokemon", TestInstance);
        }

        [When(@"the test user resets the Pokemon EVs")]
        public void WhenTheTestUserResetsThePokemonEVs()
        {
            Pokemon TestInstance = GenericSteps.TestContextData["TestPokemon"];
            TestInstance.ResetEVs();
            if (GenericSteps.TestContextData.ContainsKey("TestPokemon"))
            {
                GenericSteps.TestContextData.Remove("TestPokemon");
            }
            GenericSteps.TestContextData.Add("TestPokemon", TestInstance);
        }


        [Then(@"HP stat should have '(.*)' EV points")]
        public void ThenHPStatShouldHaveEVPoints(int p0)
        {
            Pokemon TestInstance = GenericSteps.TestContextData["TestPokemon"];
            int points = TestInstance.EVsHP;
            Assert.True(p0.Equals(points));
        }



        [Then(@"the result Pokemon should '(.*)' be shiny")]
        public static void TheResultPokemonShouldBeShiny(string shiny)
        {
            Pokemon TestInstance = GenericSteps.TestContextData["TestPokemon"];
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
