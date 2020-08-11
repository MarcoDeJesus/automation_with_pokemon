using OpenQA.Selenium;
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
            string searchMethod = SelectorMethod.ToLower();
            string searchLocator = Selector;
            switch (searchMethod)
            {
                case "id":
                    IReadOnlyList<IWebElement> ElementsListID = driver.FindElements(By.Id(searchLocator));
                    foreach (IWebElement element in ElementsListID)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "class":
                    IReadOnlyList<IWebElement> ElementsListClass = driver.FindElements(By.ClassName(searchLocator));
                    foreach (IWebElement element in ElementsListClass)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "name":
                    IReadOnlyList<IWebElement> ElementsListName = driver.FindElements(By.Name(searchLocator));
                    foreach (IWebElement element in ElementsListName)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "css":
                    IReadOnlyList<IWebElement> ElementsListCss = driver.FindElements(By.CssSelector(searchLocator));
                    foreach (IWebElement element in ElementsListCss)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "xpath":
                    IReadOnlyList<IWebElement> ElementsListXpath = driver.FindElements(By.XPath(searchLocator));
                    foreach (IWebElement element in ElementsListXpath)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
                case "linktext":
                    IReadOnlyList<IWebElement> ElementsListLinkText = driver.FindElements(By.LinkText(searchLocator));
                    foreach (IWebElement element in ElementsListLinkText)
                    {
                        AllMatchingResults.Add(element);
                    }
                    break;
            }
        }

    }
}
