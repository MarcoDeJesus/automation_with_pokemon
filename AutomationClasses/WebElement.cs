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


    }
}
