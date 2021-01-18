using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDBHome
    {
        public WebElement NationalDexQuickLink = new WebElement("main[id='main'] a[href='/pokedex/national']", "css");
        public IWebDriver _driver;

        public PokemonDBHome(IWebDriver driver)
        {
            _driver = driver;
        }


        public WebElement ClickNationalDexLink()
        {
            WebPage genericPage = new WebPage(_driver);
            NationalDexQuickLink = genericPage.ClickElement(NationalDexQuickLink);
            return NationalDexQuickLink;
        }

    }
}
