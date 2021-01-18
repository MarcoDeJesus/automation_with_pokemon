using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDetailPagePokedex
    {
        public WebElement PokemonNameHeader = new WebElement("main[id='main']>h1","css");
        public WebElement TabBasicContainer = new WebElement("div[class='tabs-panel active'][id^='tab-basic-']", "css");
        public WebElement TabBasicContainer_DataContainer = new WebElement("div:nth-child(1)>div[class$='text-center']+div:nth-child(2)>h2+table.vitals-table", "css");
        public WebElement TabBasicContainer_DataContainer_NationalDexNumber = new WebElement("tbody>tr:nth-child(1) >td", "css");
        public WebElement TabBasicContainer_DataContainer_PokemonTypes = new WebElement("tbody>tr:nth-child(2)>td>a", "css");
        public IWebDriver _driver;

        public PokemonDetailPagePokedex(IWebDriver driver)
        {
            _driver = driver;
        }

        public WebElement FindNationalDexNumberLabel()
        {
            TabBasicContainer.SearchForThisElement(_driver);
            TabBasicContainer_DataContainer = TabBasicContainer.SearchForAnElementInsideThisElement(TabBasicContainer_DataContainer);
            TabBasicContainer_DataContainer_NationalDexNumber = TabBasicContainer_DataContainer.SearchForAnElementInsideThisElement(TabBasicContainer_DataContainer_NationalDexNumber);
            return TabBasicContainer_DataContainer_NationalDexNumber;
        }

        public WebElement FindPokemonNameHeaderLabel()
        {
            PokemonNameHeader.SearchForThisElement(_driver);
            return PokemonNameHeader;
        }

        public WebElement FindPokemonTypesLabels()
        {
            TabBasicContainer.SearchForThisElement(_driver);
            TabBasicContainer_DataContainer = TabBasicContainer.SearchForAnElementInsideThisElement(TabBasicContainer_DataContainer);
            TabBasicContainer_DataContainer_PokemonTypes = TabBasicContainer_DataContainer.SearchForAnElementInsideThisElement(TabBasicContainer_DataContainer_PokemonTypes);
            return TabBasicContainer_DataContainer_PokemonTypes;
        }

    }
}
