using AutomationProject.Layer2.UI;
using Features;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects;
using PokemonTypesNamespace;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using UIModules;

namespace TestsSteps
{
    [Binding]
    public class GenericSteps
    {
        public bool isWebTest = false;
        public Dictionary<string, dynamic> TestContextData = new Dictionary<string, dynamic>(); 
        public IWebDriver _driver;

        #region GenericSteps
        [AfterScenario]
        public void CloseBrowser()
        {
            if (isWebTest == true)
            {
                _driver.Close();
            }
        }


        [BeforeScenario]
        public void ClearStaticVariables()
        {
            if (isWebTest == true)
            {
                TestContextData.Clear();
            }
        }

        #endregion


        #region PokemonStatsPage Steps

        [Given(@"that the test user has selected a the '(.*)' Pokemon for this test")]
        public void GivenThatTheTestUserHasSelectedAThePokemonForThisTest(string name)
        {
            if (TestContextData.ContainsKey("PokemonName"))
            {
                TestContextData.Remove("PokemonName");
            }
            if (TestContextData.ContainsKey("TestPokemon"))
            {
                TestContextData.Remove("TestPokemon");
            }
            name = name.ToLower();
            TestContextData.Add("PokemonName", name);
            GivenThatTheUserHasSelectedThePokemon(name);
            WhenTheTestUserQueriesThePokemonAPIWithTheSelectedPokemon();
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            TestContextData.Add("TestPokemon", TestPokemon);

        }

        [Given(@"that the test user has navigated to the Pokemon DataBase page")]
        public void GivenThatTheTestUserHasNavigatedToThePokemonDataBasePage()
        {

            WebPage genericPage = new WebPage();
            genericPage.OpenBrowser("gc");
            genericPage.MaximizeWindow();
            genericPage.LoadWebPage("https://pokemondb.net/");
            _driver = genericPage.WebDriver;
            isWebTest = true;
        }


        [Given(@"that the user has navigated to the National Pokedex List with the Quick Link in Home Page")]
        public void GivenThatTheUserHasNavigatedToTheNationalPokedexListWithTheQuickLinkInHomePage()
        {
            PokemonDBHomeModule HomeModule = new PokemonDBHomeModule(_driver);
            HomeModule.UserClicksNationalPokedexQuickLink();
        }


        [When(@"the user loads the Pokemon DB Detail page for the selected Pokemon")]
        public void WhenTheUserLoadsThePokemonDBDetailPageForTheSelectedPokemon()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            string url = "https://pokemondb.net/pokedex/" + TestPokemon.Name;
            WebPage genericPage = new WebPage();
            genericPage.OpenBrowser("gc");
            genericPage.MaximizeWindow();
            genericPage.LoadWebPage(url);
            _driver = genericPage.WebDriver;
            isWebTest = true;
        }



        [When(@"the user selects the Test Pokemon from the list of Pokemon")]
        public void WhenTheUserSelectsTheTestPokemonFromTheListOfPokemon()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            NationalPokedexPageModule NatModule = new NationalPokedexPageModule(_driver);
            NatModule.UserClicksPokemonFromTheList(TestPokemon.Name.ToLower());
        }

        [Then(@"the Pokemon Pokedex entry should display the pokemon name in the header label")]
        public void ThenThePokemonPokedexEntryShouldDisplayThePokemonNameInTheHeaderLabel()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule(_driver);
            string name = DetailMod.FindPokemonNameInPage().ToLower();
            string nameAPI = TestPokemon.Name;
            Assert.IsTrue(name.Equals(nameAPI));
        }


        [Then(@"the Pokemon Pokedex entry should display the correct National Dex")]
        public void ThenThePokemonPokedexEntryShouldDisplayTheCorrectNationalDex()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule(_driver);
            string number = DetailMod.FindPokemonNationalNumber();
            string numberAPI = TestPokemon.Number.ToString();
            Assert.IsTrue(number.Equals(numberAPI));
        }


        [Then(@"the Pokemon Pokedex entry should display a correct primary type")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectPrimaryType()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonTypes PrimaryTypeObject = TestPokemon.GetThisPokemonPrimaryType();
            string primaryAPI = PrimaryTypeObject.TypeName.ToLower();
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule(_driver);
            string primaryUI = DetailMod.GetPokemonPrimaryType();
            Assert.IsTrue(primaryAPI.Equals(primaryUI.ToLower()));
        }

        [Then(@"the Pokemon Pokedex entry should display a correct secondary type")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectSecondaryType()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule(_driver);
            bool hasSecondaryAPI = TestPokemon.ThisPokemonHasASecondType();
            if (hasSecondaryAPI)
            {
                PokemonTypes SecondTypeObject = TestPokemon.GetThisPokemonSecondaryType();
                string secondAPI = SecondTypeObject.TypeName.ToLower();
                bool hasSecondaryUI = DetailMod.ThisPokemonHasASecondType();
                Assert.IsTrue(hasSecondaryAPI.Equals(hasSecondaryUI));
                string secondUI = DetailMod.GetPokemonSecondaryType();
                Assert.IsTrue(secondAPI.Equals(secondUI.ToLower()));
            }
            else
            {
                bool hasSecondaryUI = DetailMod.ThisPokemonHasASecondType();
                Assert.IsTrue(hasSecondaryAPI.Equals(hasSecondaryUI));
            }
        }

        [Then(@"the Pokemon Pokedex entry should display a correct Base HP stat value")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectBaseHPStatValue()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule(_driver);
            string Hp = DetailMod.FindPokemonBaseHP();
            int HpAPI = TestPokemon.BaseHP;
            Assert.IsTrue(Hp.Equals(HpAPI.ToString()));
        }

        [Then(@"the Pokemon Pokedex entry should display a correct Base Attack stat value")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectBaseAttackStatValue()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule(_driver);
            string att = DetailMod.FindPokemonBaseAttack();
            int attAPI = TestPokemon.BaseAttack;
            Assert.IsTrue(att.Equals(attAPI.ToString()));
        }

        [Then(@"the Pokemon Pokedex entry should display a correct Base Defense stat value")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectBaseDefenseStatValue()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule(_driver);
            string def = DetailMod.FindPokemonBaseDefense();
            int defAPI = TestPokemon.BaseDefense;
            Assert.IsTrue(def.Equals(defAPI.ToString()));
        }

        [Then(@"the Pokemon Pokedex entry should display a correct Base Sp\. Attack stat value")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectBaseSp_AttackStatValue()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule(_driver);
            string att = DetailMod.FindPokemonBaseSpAttack();
            int attAPI = TestPokemon.BaseSpecialAttack;
            Assert.IsTrue(att.Equals(attAPI.ToString()));
        }

        [Then(@"the Pokemon Pokedex entry should display a correct Base Sp\. Defense stat value")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectBaseSp_DefenseStatValue()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule(_driver);
            string def = DetailMod.FindPokemonBaseSpDefense();
            int defAPI = TestPokemon.BaseSpecialDefense;
            Assert.IsTrue(def.Equals(defAPI.ToString()));
        }

        [Then(@"the Pokemon Pokedex entry should display a correct Base Speed stat value")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectBaseSpeedStatValue()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule(_driver);
            string spe = DetailMod.FindPokemonBaseSpeed();
            int speAPI = TestPokemon.BaseSpeed;
            Assert.IsTrue(spe.Equals(speAPI.ToString()));
        }
        #endregion


        #region PokemonClass Steps
        [Given(@"that the test user has selects '(.*)' as the test Pokemon")]
        public void ThatTheTestUserHasSelectsAsTheTestPokemon(string p0)
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
        public void TheTestUserGeneratesAnInstanceUsingOnlyTheIsShinyFlagAs(string p0)
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
        public void TheResultPokemonShouldBeShiny(string shiny)
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
        #endregion


        #region PokemonEndpoint Steps
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
        #endregion


    }
}
