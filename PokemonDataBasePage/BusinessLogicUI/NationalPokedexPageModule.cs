using OpenQA.Selenium;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIModules
{
    class NationalPokedexPageModule
    {
        public WebPage _wp;
        private string WebBrowser;


        public NationalPokedexPageModule(WebPage wp)
        {
            _wp = wp;
        }

        public void GoToThisPage()
        {
            _wp.LoadWebPage("https://pokemondb.net/pokedex/national");
        }


        public void UserClicksPokemonFromTheList(string name)
        {
            NationalPokedexPage NDPage = new NationalPokedexPage(_wp);
            NDPage.MoveIntoViewToPokemonNamed(name);
            NDPage.ClickPokemonTileNamed(name);
        }



    }
}
