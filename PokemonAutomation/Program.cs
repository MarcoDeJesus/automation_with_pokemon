
using OpenQA.Selenium;
using PageObjects;
using System;
using System.Threading;
using UIModules;

namespace AutomationProject
{
    class Program
    {
        static void Main(string[] args)
        {

            WebPage genericBrowser = new WebPage();
            genericBrowser.OpenBrowser("gc");
            genericBrowser.LoadWebPage("https://the-internet.herokuapp.com/login");
            LoginPage lp = new LoginPage(genericBrowser.WebDriver);
            lp.ClickLoginButton();
            Thread.Sleep(2000);

            /**
            bool useAbstraction = true;
            if (useAbstraction)
            {
                WebPage genericBrowser = new WebPage();
                genericBrowser.OpenBrowser("gc");
                NationalPokedexPageModule ndex = new NationalPokedexPageModule(genericBrowser.WebDriver);
                ndex.GoToThisPage();
                ndex.UserClicksPokemonFromTheList("Lugia");
            }
            else
            {
                WebPage genericBrowser = new WebPage();
                genericBrowser.OpenBrowser("gc");
                genericBrowser.LoadWebPage("https://pokemondb.net/pokedex/national");
                NationalPokedexPage NDPage = new NationalPokedexPage(genericBrowser.WebDriver);
                NDPage.FindPokemonTiles();
                NDPage.MoveIntoViewToPokemonNamed("Lugia");
                NDPage.ClickPokemonTileNamed("Lugia");
            }**/



        }
    }
}
