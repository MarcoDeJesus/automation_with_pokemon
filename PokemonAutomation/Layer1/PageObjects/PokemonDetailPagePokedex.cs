using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDetailPagePokedex
    {
        public WebElement PokemonNameHeader = new WebElement("main[id='main']>h1","css");
        public WebElement NationalDexNumber = new WebElement("div[id^='tab-basic-']:nth-of-type(1)>div:nth-child(1)>div:nth-child(2)>h2+table.vitals-table>tbody>tr:nth-child(1)>td", "css");
        public WebElement PokemonTypes = new WebElement("div[id^='tab-basic-']:nth-of-type(1)>div:nth-child(1)>div:nth-child(2)>h2+table.vitals-table>tbody>tr:nth-child(2)>td>a", "css");

        public WebElement FindNationalDexNumberLabel()
        {
            NationalDexNumber.SearchForThisElement();
            return NationalDexNumber;
        }

        public WebElement FindPokemonNameHeaderLabel()
        {
            PokemonNameHeader.SearchForThisElement();
            return PokemonNameHeader;
        }

        public WebElement FindPokemonTypesLabels()
        {
            PokemonTypes.SearchForThisElement();
            return PokemonTypes;
        }

    }
}
