using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDBHome
    {
        public WebElement NationalDexQuickLink = new WebElement("main[id='main'] a[href='/pokedex/national']", "css");

        public WebElement ClickNationalDexLink()
        {
            NationalDexQuickLink = WebPage.ClickElement(NationalDexQuickLink);
            return NationalDexQuickLink;
        }

    }
}
