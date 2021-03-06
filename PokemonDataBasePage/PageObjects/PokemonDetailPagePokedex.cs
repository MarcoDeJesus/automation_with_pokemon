﻿using OpenQA.Selenium;
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
        public WebPage _webPage;

        public PokemonDetailPagePokedex(WebPage webPage)
        {
                _webPage = webPage;
        }

        public WebElement FindNationalDexNumberLabel()
        {
            TabBasicContainer = _webPage.SearchForThisElement(TabBasicContainer);
            TabBasicContainer_DataContainer = _webPage.SearchForAnElementInsideThisElement(TabBasicContainer, TabBasicContainer_DataContainer);
            TabBasicContainer_DataContainer_NationalDexNumber = _webPage.SearchForAnElementInsideThisElement(TabBasicContainer_DataContainer, TabBasicContainer_DataContainer_NationalDexNumber);
            return TabBasicContainer_DataContainer_NationalDexNumber;
        }

        public WebElement FindPokemonNameHeaderLabel()
        {
            PokemonNameHeader = _webPage.SearchForThisElement(PokemonNameHeader);
            return PokemonNameHeader;
        }

        public WebElement FindPokemonTypesLabels()
        {
            TabBasicContainer = _webPage.SearchForThisElement(TabBasicContainer);
            TabBasicContainer_DataContainer = _webPage.SearchForAnElementInsideThisElement(TabBasicContainer, TabBasicContainer_DataContainer);
            TabBasicContainer_DataContainer_PokemonTypes = _webPage.SearchForAnElementInsideThisElement(TabBasicContainer_DataContainer, TabBasicContainer_DataContainer_PokemonTypes);
            return TabBasicContainer_DataContainer_PokemonTypes;
        }

    }
}
