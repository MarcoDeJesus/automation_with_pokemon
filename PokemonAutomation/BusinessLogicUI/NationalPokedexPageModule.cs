using OpenQA.Selenium;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIModules
{
    class NationalPokedexPageModule
    {
        public IWebDriver CurrentDriver;
        private string WebBrowser;


        public NationalPokedexPageModule(IWebDriver driver)
        {
            CurrentDriver = driver;
        }

        public void GoToThisPage()
        {
            CurrentDriver.Navigate().GoToUrl("https://pokemondb.net/pokedex/national");
        }


        public void UserClicksPokemonFromTheList(string name)
        {
            NationalPokedexPage NDPage = new NationalPokedexPage(CurrentDriver);
            NDPage.MoveIntoViewToPokemonNamed(name);
            NDPage.ClickPokemonTileNamed(name);
        }



    }
}
