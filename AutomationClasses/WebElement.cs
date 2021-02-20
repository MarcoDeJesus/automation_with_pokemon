using OpenQA.Selenium;
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
        public int AmountElements { get; private set; } = 0;


        public WebElement()
        {
            Selector = null;
            SelectorMethod = null;
        }


        public void ResetElement()
        {
            AllMatchingResults.Clear();
            AmountElements = 0;
        }


        public WebElement(string selector, string selectorMethod)
        {
            Selector = selector;
            SelectorMethod = selectorMethod;
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
