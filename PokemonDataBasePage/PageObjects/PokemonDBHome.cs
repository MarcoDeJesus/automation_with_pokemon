using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDBHome
    {
        public WebElement NationalDexQuickLink = new WebElement("main[id='main'] a[href='/pokedex/national']", "css");
        public WebPage _webPage;

        public PokemonDBHome(WebPage webPage)
        {
                _webPage = webPage;
        }


        public WebElement ClickNationalDexLink()
        {
            NationalDexQuickLink = _webPage.ClickElement(NationalDexQuickLink);
            return NationalDexQuickLink;
        }

    }
}
