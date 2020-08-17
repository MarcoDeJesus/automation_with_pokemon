using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace PageObjects
{
    public class WebElement
    {
        public string Selector;
        public string SelectorMethod;
        public List<IWebElement> AllMatchingResults = new List<IWebElement>();


        public WebElement()
        {
            Selector = null;
            SelectorMethod = null;
        }


        public WebElement(string selector, string selectorMethod)
        {
            Selector = selector;
            SelectorMethod = selectorMethod;
        }

        public void SearchForThisElement()
        {
            switch (SelectorMethod.ToLower())
            {
                case "id":
                    IReadOnlyList<IWebElement> ElementsListID = WebPage.WebDriver.FindElements(By.Id(Selector));
                    foreach (IWebElement element in ElementsListID)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "class":
                    IReadOnlyList<IWebElement> ElementsListClass = WebPage.WebDriver.FindElements(By.ClassName(Selector));
                    foreach (IWebElement element in ElementsListClass)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "name":
                    IReadOnlyList<IWebElement> ElementsListName = WebPage.WebDriver.FindElements(By.Name(Selector));
                    foreach (IWebElement element in ElementsListName)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "css":
                    IReadOnlyList<IWebElement> ElementsListCss = WebPage.WebDriver.FindElements(By.CssSelector(Selector));
                    foreach (IWebElement element in ElementsListCss)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "xpath":
                    IReadOnlyList<IWebElement> ElementsListXpath = WebPage.WebDriver.FindElements(By.XPath(Selector));
                    foreach (IWebElement element in ElementsListXpath)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "linktext":
                    IReadOnlyList<IWebElement> ElementsListLinkText = WebPage.WebDriver.FindElements(By.LinkText(Selector));
                    foreach (IWebElement element in ElementsListLinkText)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
            }
        }

    }
}
