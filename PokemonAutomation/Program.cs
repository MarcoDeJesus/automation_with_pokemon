
using OpenQA.Selenium;
using PageObjects;
using System;
using System.Threading;

namespace AutomationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            WebPage.OpenBrowser("gc");
            WebPage.LoadWebPage("https://pokemondb.net/pokedex/national");
            NationalPokedexPage NDPage = new NationalPokedexPage();
            NDPage.FindPokemonTiles();
            string wantedPokemon = "Articuno";
            foreach (IWebElement iwe in NDPage.PokemonTile.AllMatchingResults)
            {
                if (iwe.Text == wantedPokemon)
                {
                    NDPage.SpecificPokemonTile.SelectorMethod = "css";
                    NDPage.SpecificPokemonTile.AllMatchingResults.Add(iwe);
                    break;
                }
            }
            Thread.Sleep(1000);
            NDPage.MoveIntoViewToTile();
            Thread.Sleep(1000);
            NDPage.ClickPokemonTile();
            Thread.Sleep(5000);


        }
    }
}
