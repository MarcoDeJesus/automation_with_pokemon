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

        public void SearchForThisElement(IWebDriver driver)
        {
            switch (SelectorMethod.ToLower())
            {
                case "id":
                    IReadOnlyList<IWebElement> ElementsListID = driver.FindElements(By.Id(Selector));
                    foreach (IWebElement element in ElementsListID)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "class":
                    IReadOnlyList<IWebElement> ElementsListClass = driver.FindElements(By.ClassName(Selector));
                    foreach (IWebElement element in ElementsListClass)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "name":
                    IReadOnlyList<IWebElement> ElementsListName = driver.FindElements(By.Name(Selector));
                    foreach (IWebElement element in ElementsListName)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "css":
                    IReadOnlyList<IWebElement> ElementsListCss = driver.FindElements(By.CssSelector(Selector));
                    foreach (IWebElement element in ElementsListCss)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "xpath":
                    IReadOnlyList<IWebElement> ElementsListXpath = driver.FindElements(By.XPath(Selector));
                    foreach (IWebElement element in ElementsListXpath)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "linktext":
                    IReadOnlyList<IWebElement> ElementsListLinkText = driver.FindElements(By.LinkText(Selector));
                    foreach (IWebElement element in ElementsListLinkText)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
            }
        }

    }
}
