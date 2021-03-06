﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDetailPageNavigationBar
    {
        public WebElement InfoLink = new WebElement("a[href='#dex-basics']","css");
        public WebElement BaseStatsLink = new WebElement("a[href='#dex-stats']", "css");
        public WebElement EvolutionChartLink = new WebElement("a[href='#dex-evolution']", "css");
        public WebElement PokedexEntriesLink = new WebElement("a[href='#dex-flavor']", "css");
        public WebElement MovesLearnedLink = new WebElement("a[href='#dex-moves']", "css");
        public WebElement SpritesLink = new WebElement("a[href='#dex-sprites']", "css");
        public WebElement LocationsLink = new WebElement("a[href='#dex-locations']", "css");
        public WebElement LanguageLink = new WebElement("a[href='#dex-lang']", "css");
        public WebPage _webPage;

        public PokemonDetailPageNavigationBar(WebPage webPage)
        {
                _webPage = webPage;
        }

        public WebElement ClickInfoLink()
        {
            InfoLink = _webPage.ClickElement(InfoLink);
            return InfoLink;
        }

        public WebElement ClickBaseStatsLink()
        {
            BaseStatsLink = _webPage.ClickElement(BaseStatsLink);
            return BaseStatsLink;
        }

    }
}
