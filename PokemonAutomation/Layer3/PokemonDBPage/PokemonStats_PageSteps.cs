using APIModules;
using AutomationProject.Layer2.UI;
using NUnit.Framework;
using PageObjects;
using PokemonTypesNamespace;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using UIModules;

namespace TestsSteps
{
    [Binding]
    public class PokemonStats_PageSteps
    {
        public static Dictionary<string, dynamic> TestContextData = new Dictionary<string, dynamic>();

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
            Pokemon_EndpointSteps.GivenThatTheUserHasSelectedThePokemon(name);
            Pokemon_EndpointSteps.WhenTheTestUserQueriesThePokemonAPIWithTheSelectedPokemon();
            PokemonFactory TestPokemon = Pokemon_EndpointSteps.TestContextData["TestPokemon"];
            TestContextData.Add("TestPokemon", TestPokemon);

        }
        
        [Given(@"that the test user has navigated to the Pokemon DataBase page")]
        public void GivenThatTheTestUserHasNavigatedToThePokemonDataBasePage()
        {
            WebPage.OpenWebBrowser("gc");
            WebPage.MaximizeWindow();
            WebPage.LoadWebPage("https://pokemondb.net/");
            GenericSteps.isWebTest = true;
        }


        [Given(@"that the user has navigated to the National Pokedex List with the Quick Link in Home Page")]
        public void GivenThatTheUserHasNavigatedToTheNationalPokedexListWithTheQuickLinkInHomePage()
        {
            PokemonDBHomeModule HomeModule = new PokemonDBHomeModule();
            HomeModule.UserClicksNationalPokedexQuickLink();
        }


        [When(@"the user loads the Pokemon DB Detail page for the selected Pokemon")]
        public void WhenTheUserLoadsThePokemonDBDetailPageForTheSelectedPokemon()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            string url = "https://pokemondb.net/pokedex/"+TestPokemon.Name;
            WebPage.OpenWebBrowser("gc");
            WebPage.MaximizeWindow();
            WebPage.LoadWebPage(url);
            GenericSteps.isWebTest = true;
        }



        [When(@"the user selects the Test Pokemon from the list of Pokemon")]
        public void WhenTheUserSelectsTheTestPokemonFromTheListOfPokemon()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            NationalPokedexPageModule NatModule = new NationalPokedexPageModule();
            NatModule.UserClicksPokemonFromTheList(TestPokemon.Name.ToLower());
        }
        
        [Then(@"the Pokemon Pokedex entry should display the pokemon name in the header label")]
        public void ThenThePokemonPokedexEntryShouldDisplayThePokemonNameInTheHeaderLabel()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule();
            string name = DetailMod.FindPokemonNameInPage().ToLower();
            string nameAPI = TestPokemon.Name;
            Assert.IsTrue(name.Equals(nameAPI));
        }
        
        [Then(@"the Pokemon Pokedex entry should display a correct primary type")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectPrimaryType()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonTypes PrimaryTypeObject = TestPokemon.GetThisPokemonPrimaryType();
            string primaryAPI = PrimaryTypeObject.TypeName.ToLower();
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule();
            string primaryUI = DetailMod.GetPokemonPrimaryType();
            Assert.IsTrue(primaryAPI.Equals(primaryUI.ToLower()));
        }

        [Then(@"the Pokemon Pokedex entry should display a correct secondary type")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectSecondaryType()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule();
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
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule();
            string Hp = DetailMod.FindPokemonBaseHP();
            int HpAPI = TestPokemon.BaseHP;
            Assert.IsTrue(Hp.Equals(HpAPI.ToString()));
        }
        
        [Then(@"the Pokemon Pokedex entry should display a correct Base Attack stat value")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectBaseAttackStatValue()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule();
            string att = DetailMod.FindPokemonBaseAttack();
            int attAPI = TestPokemon.BaseAttack;
            Assert.IsTrue(att.Equals(attAPI.ToString()));
        }
        
        [Then(@"the Pokemon Pokedex entry should display a correct Base Defense stat value")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectBaseDefenseStatValue()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule();
            string def = DetailMod.FindPokemonBaseDefense();
            int defAPI = TestPokemon.BaseDefense;
            Assert.IsTrue(def.Equals(defAPI.ToString()));
        }
        
        [Then(@"the Pokemon Pokedex entry should display a correct Base Sp\. Attack stat value")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectBaseSp_AttackStatValue()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule();
            string att = DetailMod.FindPokemonBaseSpAttack();
            int attAPI = TestPokemon.BaseSpecialAttack;
            Assert.IsTrue(att.Equals(attAPI.ToString()));
        }
        
        [Then(@"the Pokemon Pokedex entry should display a correct Base Sp\. Defense stat value")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectBaseSp_DefenseStatValue()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule();
            string def = DetailMod.FindPokemonBaseSpDefense();
            int defAPI = TestPokemon.BaseSpecialDefense;
            Assert.IsTrue(def.Equals(defAPI.ToString()));
        }
        
        [Then(@"the Pokemon Pokedex entry should display a correct Base Speed stat value")]
        public void ThenThePokemonPokedexEntryShouldDisplayACorrectBaseSpeedStatValue()
        {
            PokemonFactory TestPokemon = TestContextData["TestPokemon"];
            PokemonDetailPageModule DetailMod = new PokemonDetailPageModule();
            string spe = DetailMod.FindPokemonBaseSpeed();
            int speAPI = TestPokemon.BaseSpeed;
            Assert.IsTrue(spe.Equals(speAPI.ToString()));
        }
    }
}
