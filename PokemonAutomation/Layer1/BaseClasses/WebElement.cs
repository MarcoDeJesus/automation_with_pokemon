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
            AllMatchingResults.Clear();
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

        public WebElement SearchForAnElementInsideThisElement(WebElement cwe)
        {
            string _SelectorMethod = cwe.SelectorMethod;
            string _Selector = cwe.Selector;
            IWebElement _ipw = AllMatchingResults[0];
            switch (_SelectorMethod.ToLower())
            {
                case "id":
                    IReadOnlyList<IWebElement> ElementsListID = _ipw.FindElements(By.Id(_Selector));
                    foreach (IWebElement element in ElementsListID)
                    {
                        cwe.AllMatchingResults.Add(element);
                    }
                    break;
                case "class":
                    IReadOnlyList<IWebElement> ElementsListClass = _ipw.FindElements(By.ClassName(_Selector));
                    foreach (IWebElement element in ElementsListClass)
                    {
                        cwe.AllMatchingResults.Add(element);
                    }
                    break;
                case "name":
                    IReadOnlyList<IWebElement> ElementsListName = _ipw.FindElements(By.Name(_Selector));
                    foreach (IWebElement element in ElementsListName)
                    {
                        cwe.AllMatchingResults.Add(element);
                    }
                    break;
                case "css":
                    IReadOnlyList<IWebElement> ElementsListCss = _ipw.FindElements(By.CssSelector(_Selector));
                    foreach (IWebElement element in ElementsListCss)
                    {
                        cwe.AllMatchingResults.Add(element);
                    }
                    break;
                case "xpath":
                    IReadOnlyList<IWebElement> ElementsListXpath = _ipw.FindElements(By.XPath(_Selector));
                    foreach (IWebElement element in ElementsListXpath)
                    {
                        cwe.AllMatchingResults.Add(element);
                    }
                    break;
                case "linktext":
                    IReadOnlyList<IWebElement> ElementsListLinkText = _ipw.FindElements(By.LinkText(_Selector));
                    foreach (IWebElement element in ElementsListLinkText)
                    {
                        cwe.AllMatchingResults.Add(element);
                    }
                    break;
            }
            return cwe;
        }


    }
}
