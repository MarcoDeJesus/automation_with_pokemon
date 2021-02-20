using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects;
using System;
using UIModules;

namespace CodeExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            bool abstracted = true;
            if (abstracted)
            {
                WebPage wp = new WebPage("gc");
                wp.MaximizeWindow();
                PokemonDBHomeModule dbHome = new PokemonDBHomeModule(wp);
                dbHome.GoToThisPage();

                WebElement normalLink = new WebElement("a[href='/type/normal']", "css");
                bool wasFound = wp.SearchUntilElementIsPresent(normalLink);
                Console.WriteLine(wasFound);

                wp.UpdateExplicitWait(3);
                WebElement notPresentElement = new WebElement("a[href='/type/tacoType']", "css"); //It will wait for 3 seconds and try to find it every 10 ms
                wasFound = wp.SearchUntilElementIsPresent(notPresentElement);
                Console.WriteLine(wasFound);

                dbHome.CloseModalIfPresent();
                dbHome.UserClicksNationalPokedexQuickLink();
                wp.CloseBrowser();
            }
            else 
            {
                WebPage wp = new WebPage("gc");
                wp.MaximizeWindow();
                wp.LoadWebPage("https://pokemondb.net/");

                WebElement normalLink = new WebElement("a[href='/type/normal']", "css");
                bool wasFound = wp.SearchUntilElementIsPresent(normalLink);
                Console.WriteLine(wasFound);

                wp.UpdateExplicitWait(3);
                WebElement notPresentElement = new WebElement("a[href='/type/tacoType']", "css"); //It will wait for 3 seconds and try to find it every 10 ms
                wasFound = wp.SearchUntilElementIsPresent(notPresentElement);
                Console.WriteLine(wasFound);

                WebElement NationalDexQuickLink = new WebElement("main[id='main'] a[href='/pokedex/national']", "css");
                WebElement ModalOkButton = new WebElement("button[class='btn btn-primary gdpr-accept']", "css");

                wp.SearchForThisElement(ModalOkButton);
                if (ModalOkButton.AmountElements == 1)
                {
                    wp.ClickElement(ModalOkButton);
                }
                wp.ClickElement(NationalDexQuickLink);

                wp.CloseBrowser();
            }
        }
    }
}
