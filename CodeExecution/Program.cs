using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects;
using System;

namespace CodeExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            WebPage wp = new WebPage();
            wp.OpenBrowser("gc");
            wp.LoadWebPage("https://pokemondb.net/");
            WebElement normalLink = new WebElement("a[href='/type/normal']","css");
            bool wasIt = wp.SearchUntilElementIsPresent(normalLink);
            Console.WriteLine(wasIt);
            wp.CloseBrowser();

        }
    }
}
