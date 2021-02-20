using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDetailPageStats
    {
        public WebElement TabBasicContainer = new WebElement("div[class='tabs-panel active'][id^='tab-basic-']", "css");
        public WebElement TabBasicContainer_StatsContainer = new WebElement("div:nth-child(2)>div:nth-child(1)", "css");
        public WebElement TabBasicContainer_StatsContainer_BaseStatHP = new WebElement("table.vitals-table tbody>tr:nth-child(1) td:nth-of-type(1)", "css");
        public WebElement TabBasicContainer_StatsContainer_BaseStatAttack = new WebElement("table.vitals-table tbody>tr:nth-child(2) td:nth-of-type(1)", "css");
        public WebElement TabBasicContainer_StatsContainer_BaseStatDefense = new WebElement("table.vitals-table tbody>tr:nth-child(3) td:nth-of-type(1)", "css");
        public WebElement TabBasicContainer_StatsContainer_BaseStatSpAttack = new WebElement("table.vitals-table tbody>tr:nth-child(4) td:nth-of-type(1)", "css");
        public WebElement TabBasicContainer_StatsContainer_BaseStatSpDefense = new WebElement("table.vitals-table tbody>tr:nth-child(5) td:nth-of-type(1)", "css");
        public WebElement TabBasicContainer_StatsContainer_BaseStatSpeed = new WebElement("table.vitals-table tbody>tr:nth-child(6) td:nth-of-type(1)", "css");
        public WebPage _webPage;

        public PokemonDetailPageStats(WebPage webPage)
        {
                _webPage = webPage;
        }

        public WebElement FindHPBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForThisElement(TabBasicContainer);
            TabBasicContainer_StatsContainer = TabBasicContainer.SearchForAnElementInsideThisElement(TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatHP = TabBasicContainer_StatsContainer.SearchForAnElementInsideThisElement(TabBasicContainer_StatsContainer_BaseStatHP);
            return TabBasicContainer_StatsContainer_BaseStatHP;
        }

        public WebElement FindAttackBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForThisElement(TabBasicContainer);
            TabBasicContainer_StatsContainer = TabBasicContainer.SearchForAnElementInsideThisElement(TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatAttack = TabBasicContainer_StatsContainer.SearchForAnElementInsideThisElement(TabBasicContainer_StatsContainer_BaseStatAttack);
            return TabBasicContainer_StatsContainer_BaseStatAttack;
        }

        public WebElement FindDefenseBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForThisElement(TabBasicContainer);
            TabBasicContainer_StatsContainer = TabBasicContainer.SearchForAnElementInsideThisElement(TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatDefense = TabBasicContainer_StatsContainer.SearchForAnElementInsideThisElement(TabBasicContainer_StatsContainer_BaseStatDefense);
            return TabBasicContainer_StatsContainer_BaseStatDefense;
        }

        public WebElement FindSpAttackBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForThisElement(TabBasicContainer);
            TabBasicContainer_StatsContainer = TabBasicContainer.SearchForAnElementInsideThisElement(TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatSpAttack = TabBasicContainer_StatsContainer.SearchForAnElementInsideThisElement(TabBasicContainer_StatsContainer_BaseStatSpAttack);
            return TabBasicContainer_StatsContainer_BaseStatSpAttack;
        }

        public WebElement FindSpDefenseBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForThisElement(TabBasicContainer);
            TabBasicContainer_StatsContainer = TabBasicContainer.SearchForAnElementInsideThisElement(TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatSpDefense = TabBasicContainer_StatsContainer.SearchForAnElementInsideThisElement(TabBasicContainer_StatsContainer_BaseStatSpDefense);
            return TabBasicContainer_StatsContainer_BaseStatSpDefense;
        }

        public WebElement FindSpeedBaseStatusData()
        {
            TabBasicContainer = _webPage.SearchForThisElement(TabBasicContainer);
            TabBasicContainer_StatsContainer = TabBasicContainer.SearchForAnElementInsideThisElement(TabBasicContainer_StatsContainer);
            TabBasicContainer_StatsContainer_BaseStatSpeed = TabBasicContainer_StatsContainer.SearchForAnElementInsideThisElement(TabBasicContainer_StatsContainer_BaseStatSpeed);
            return TabBasicContainer_StatsContainer_BaseStatSpeed;
        }



    }
}
