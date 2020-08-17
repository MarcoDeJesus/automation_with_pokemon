using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class PokemonDetailPageStats
    {
        public WebElement BaseStatHP = new WebElement("div[id^='tab-basic-']:nth-of-type(1)>div:nth-child(2)>div:nth-child(1) table.vitals-table tbody>tr:nth-child(1) td:nth-of-type(1)", "css");
        public WebElement BaseStatAttack = new WebElement("div[id^='tab-basic-']:nth-of-type(1)>div:nth-child(2)>div:nth-child(1) table.vitals-table tbody>tr:nth-child(2) td:nth-of-type(1)", "css");
        public WebElement BaseStatDefense = new WebElement("div[id^='tab-basic-']:nth-of-type(1)>div:nth-child(2)>div:nth-child(1) table.vitals-table tbody>tr:nth-child(3) td:nth-of-type(1)", "css");
        public WebElement BaseStatSpAttack = new WebElement("div[id^='tab-basic-']:nth-of-type(1)>div:nth-child(2)>div:nth-child(1) table.vitals-table tbody>tr:nth-child(4) td:nth-of-type(1)", "css");
        public WebElement BaseStatSpDefense = new WebElement("div[id^='tab-basic-']:nth-of-type(1)>div:nth-child(2)>div:nth-child(1) table.vitals-table tbody>tr:nth-child(5) td:nth-of-type(1)", "css");
        public WebElement BaseStatSpeed = new WebElement("div[id^='tab-basic-']:nth-of-type(1)>div:nth-child(2)>div:nth-child(1) table.vitals-table tbody>tr:nth-child(6) td:nth-of-type(1)", "css");

        public void FindHPBaseStatusData()
        {
            BaseStatHP.SearchForThisElement();
        }

        public void FindAttackBaseStatusData()
        {
            BaseStatAttack.SearchForThisElement();
        }

        public void FindDefenseBaseStatusData()
        {
            BaseStatDefense.SearchForThisElement();
        }

        public void FindSpAttackBaseStatusData()
        {
            BaseStatSpAttack.SearchForThisElement();
        }

        public void FindSpDefenseBaseStatusData()
        {
            BaseStatSpDefense.SearchForThisElement();
        }

        public void FindSpeedBaseStatusData()
        {
            BaseStatSpeed.SearchForThisElement();
        }



    }
}
