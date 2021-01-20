﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public class WebElement
    {
        public string Selector;
        public string SelectorMethod;
        public List<IWebElement> AllMatchingResults = new List<IWebElement>();
        public int AmountElements { get; private set; }


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
            AllMatchingResults.Clear();
            int count = 0;
            WebPage genericPage = new WebPage(driver);
            switch (SelectorMethod.ToLower())
            {
                case "id":
                    IReadOnlyList<IWebElement> ElementsListID = genericPage.WebDriver.FindElements(By.Id(Selector));
                    foreach (IWebElement element in ElementsListID)
                    {
                        AllMatchingResults.Add(element);
                        count = count + 1;
                    }
                    break;
                case "class":
                    IReadOnlyList<IWebElement> ElementsListClass = genericPage.WebDriver.FindElements(By.ClassName(Selector));
                    foreach (IWebElement element in ElementsListClass)
                    {
                        AllMatchingResults.Add(element);
                        count = count + 1;
                    }
                    break;
                case "name":
                    IReadOnlyList<IWebElement> ElementsListName = genericPage.WebDriver.FindElements(By.Name(Selector));
                    foreach (IWebElement element in ElementsListName)
                    {
                        AllMatchingResults.Add(element);
                        count = count + 1;
                    }
                    break;
                case "css":
                    IReadOnlyList<IWebElement> ElementsListCss = genericPage.WebDriver.FindElements(By.CssSelector(Selector));
                    foreach (IWebElement element in ElementsListCss)
                    {
                        AllMatchingResults.Add(element);
                        count = count + 1;
                    }
                    break;
                case "xpath":
                    IReadOnlyList<IWebElement> ElementsListXpath = genericPage.WebDriver.FindElements(By.XPath(Selector));
                    foreach (IWebElement element in ElementsListXpath)
                    {
                        AllMatchingResults.Add(element);
                        count = count + 1;
                    }
                    break;
                case "linktext":
                    IReadOnlyList<IWebElement> ElementsListLinkText = genericPage.WebDriver.FindElements(By.LinkText(Selector));
                    foreach (IWebElement element in ElementsListLinkText)
                    {
                        AllMatchingResults.Add(element);
                        count = count + 1;
                    }
                    break;
            }
            AmountElements = count;
        }

        public void CountMatchingElements()
        {
            AmountElements = AllMatchingResults.Count;
        }


        public IWebElement ReturnTheIWebElementInPosition(int i)
        {
            IWebElement TestWE = null;
            if (!(i <= 0 || i > AmountElements))
            {
                TestWE = AllMatchingResults.ElementAt(i - 1);
            }
            return TestWE;
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
                    cwe.CountMatchingElements();
                    break;
                case "class":
                    IReadOnlyList<IWebElement> ElementsListClass = _ipw.FindElements(By.ClassName(_Selector));
                    foreach (IWebElement element in ElementsListClass)
                    {
                        cwe.AllMatchingResults.Add(element);
                    }
                    cwe.CountMatchingElements();
                    break;
                case "name":
                    IReadOnlyList<IWebElement> ElementsListName = _ipw.FindElements(By.Name(_Selector));
                    foreach (IWebElement element in ElementsListName)
                    {
                        cwe.AllMatchingResults.Add(element);
                    }
                    cwe.CountMatchingElements();
                    break;
                case "css":
                    IReadOnlyList<IWebElement> ElementsListCss = _ipw.FindElements(By.CssSelector(_Selector));
                    foreach (IWebElement element in ElementsListCss)
                    {
                        cwe.AllMatchingResults.Add(element);
                    }
                    cwe.CountMatchingElements();
                    break;
                case "xpath":
                    IReadOnlyList<IWebElement> ElementsListXpath = _ipw.FindElements(By.XPath(_Selector));
                    foreach (IWebElement element in ElementsListXpath)
                    {
                        cwe.AllMatchingResults.Add(element);
                    }
                    cwe.CountMatchingElements();
                    break;
                case "linktext":
                    IReadOnlyList<IWebElement> ElementsListLinkText = _ipw.FindElements(By.LinkText(_Selector));
                    foreach (IWebElement element in ElementsListLinkText)
                    {
                        cwe.AllMatchingResults.Add(element);
                    }
                    cwe.CountMatchingElements();
                    break;
            }
            return cwe;
        }


    }
}