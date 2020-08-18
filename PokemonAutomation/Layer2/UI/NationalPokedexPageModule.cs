using PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIModules
{
    class NationalPokedexPageModule
    {

        public void UserClicksPokemonFromTheList(string name)
        {
            NationalPokedexPage NDPage = new NationalPokedexPage();
            NDPage.MoveIntoViewToPokemonNamed(name);
            NDPage.ClickPokemonTileNamed(name);
        }




    }
}
