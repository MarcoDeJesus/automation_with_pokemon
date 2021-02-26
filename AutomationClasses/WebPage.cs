using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PageObjects

{
    public class WebPage
    {
        public IWebDriver WebDriver { get; set; }
        public int ImplicitWaitSeconds = 0;
        public int TimeOutSeconds = 0;
        public int explicitWait = 10;
        public int milisecondsInterval = 100;
        public WebElement testElement = new WebElement();


        public WebPage()
        {
        }

        public WebPage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public WebPage(string browser)
        {
            OpenBrowser(browser);
        }

        public void OpenBrowser(string browser)
        {
            switch (browser)
            {
                case "gc":
                    WebDriver = new ChromeDriver();
                    //WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                    break;
                case "ff":
                    WebDriver = new FirefoxDriver();
                    //WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                    break;
                default:
                    WebDriver = new ChromeDriver();
                    break;

            }
        }

        public void LoadWebPage(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public void MaximizeWindow()
        {
            WebDriver.Manage().Window.Maximize();
        }


        public void CloseBrowser()
        {
            WebDriver.Close();
        }


        public void MinimizeWindow()
        {
            WebDriver.Manage().Window.Minimize();
        }


        public void RefreshBrowser()
        {
            WebDriver.Navigate().Refresh();
        }


        public void UpdateExplicitWait(int seconds)
        {
            explicitWait = seconds;
        }


        public void UpdateTimeOut(int seconds)
        {
            TimeOutSeconds = seconds;
            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(seconds);
        }


        public WebElement GetElementText(WebElement we)
        {
            SearchForThisElement(we);
            we.elementText = null;
            if (we.AmountElements == 1)
            {
                IWebElement Result = we.ReturnTheIWebElementInPosition(1);
                we.elementText = Result.Text;
            }
            return we;
        }


        public WebElement ClickElement(WebElement we)
        {
            we = SearchForThisElement(we);
            if (we.AmountElements == 1)
            {
                IWebElement Result = we.ReturnTheIWebElementInPosition(1);
                Result.Click();
            }
            return we;
        }


        public WebElement EnterTextInElement(WebElement we, string text)
        {
            we = SearchForThisElement(we);
            if (we.AmountElements == 1)
            {
                IWebElement Result = we.ReturnTheIWebElementInPosition(1);
                Result.SendKeys(text);
            }
            return we;
        }


        public WebElement ClearTextBoxText(WebElement we)
        {
            we = SearchForThisElement(we);
            if (we.AmountElements == 1)
            {
                IWebElement Result = we.ReturnTheIWebElementInPosition(1);
                Result.SendKeys(Keys.Control + "a");
                Result.SendKeys(Keys.Delete);
            }
            return we;
        }

        public Actions NewActionsObject()
        {
            Actions actions = new Actions(WebDriver);
            return actions;
        }


        public WebElement MoveIntoViewToThisElement(WebElement we)
        {
            SearchForThisElement(we);
            if (we.AmountElements == 1)
            {
                Actions actions = NewActionsObject();
                actions.MoveToElement(we.AllMatchingResults[0]);
                actions.Perform();
            }
            return we;
        }


        public WebElement SearchForThisElement(WebElement we)
        {
            we.AllMatchingResults.Clear();
            switch (we.SelectorMethod.ToLower())
            {
                case "id":
                    IReadOnlyList<IWebElement> ElementsListID = WebDriver.FindElements(By.Id(we.Selector));
                    foreach (IWebElement element in ElementsListID)
                    {
                        we.AllMatchingResults.Add(element);
                    }
                    break;
                case "class":
                    IReadOnlyList<IWebElement> ElementsListClass = WebDriver.FindElements(By.ClassName(we.Selector));
                    foreach (IWebElement element in ElementsListClass)
                    {
                        we.AllMatchingResults.Add(element);
                    }
                    break;
                case "name":
                    IReadOnlyList<IWebElement> ElementsListName = WebDriver.FindElements(By.Name(we.Selector));
                    foreach (IWebElement element in ElementsListName)
                    {
                        we.AllMatchingResults.Add(element);
                    }
                    break;
                case "css":
                    IReadOnlyList<IWebElement> ElementsListCss = WebDriver.FindElements(By.CssSelector(we.Selector));
                    foreach (IWebElement element in ElementsListCss)
                    {
                        we.AllMatchingResults.Add(element);
                    }
                    break;
                case "xpath":
                    IReadOnlyList<IWebElement> ElementsListXpath = WebDriver.FindElements(By.XPath(we.Selector));
                    foreach (IWebElement element in ElementsListXpath)
                    {
                        we.AllMatchingResults.Add(element);
                    }
                    break;
                case "linktext":
                    IReadOnlyList<IWebElement> ElementsListLinkText = WebDriver.FindElements(By.LinkText(we.Selector));
                    foreach (IWebElement element in ElementsListLinkText)
                    {
                        we.AllMatchingResults.Add(element);
                    }
                    break;
            }
            we.CountMatchingElements();
            testElement = we;
            return we;
        }


        public WebElement SearchForAnElementInsideThisElement(WebElement parentElement, WebElement childElement)
        {
            SearchForThisElement(parentElement);
            if (parentElement.AmountElements == 1)
            {
                switch (childElement.SelectorMethod.ToLower())
                {
                    case "id":
                        IReadOnlyList<IWebElement> ElementsListID = parentElement.AllMatchingResults[0].FindElements(By.Id(childElement.Selector));
                        foreach (IWebElement element in ElementsListID)
                        {
                            childElement.AllMatchingResults.Add(element);
                        }
                        childElement.CountMatchingElements();
                        break;
                    case "class":
                        IReadOnlyList<IWebElement> ElementsListClass = parentElement.AllMatchingResults[0].FindElements(By.ClassName(childElement.Selector));
                        foreach (IWebElement element in ElementsListClass)
                        {
                            childElement.AllMatchingResults.Add(element);
                        }
                        childElement.CountMatchingElements();
                        break;
                    case "name":
                        IReadOnlyList<IWebElement> ElementsListName = parentElement.AllMatchingResults[0].FindElements(By.Name(childElement.Selector));
                        foreach (IWebElement element in ElementsListName)
                        {
                            childElement.AllMatchingResults.Add(element);
                        }
                        childElement.CountMatchingElements();
                        break;
                    case "css":
                        IReadOnlyList<IWebElement> ElementsListCss = parentElement.AllMatchingResults[0].FindElements(By.CssSelector(childElement.Selector));
                        foreach (IWebElement element in ElementsListCss)
                        {
                            childElement.AllMatchingResults.Add(element);
                        }
                        childElement.CountMatchingElements();
                        break;
                    case "xpath":
                        IReadOnlyList<IWebElement> ElementsListXpath = parentElement.AllMatchingResults[0].FindElements(By.XPath(childElement.Selector));
                        foreach (IWebElement element in ElementsListXpath)
                        {
                            childElement.AllMatchingResults.Add(element);
                        }
                        childElement.CountMatchingElements();
                        break;
                    case "linktext":
                        IReadOnlyList<IWebElement> ElementsListLinkText = parentElement.AllMatchingResults[0].FindElements(By.LinkText(childElement.Selector));
                        foreach (IWebElement element in ElementsListLinkText)
                        {
                            childElement.AllMatchingResults.Add(element);
                        }
                        childElement.CountMatchingElements();
                        break;
                }
            }
            testElement = childElement;
            return childElement;
        }


        public bool SearchUntilElementIsPresent(WebElement we)
        {
            we.AllMatchingResults.Clear();
            int timer = 0;
            bool isDisplayed = false;
            int cycles = explicitWait * 1000 / milisecondsInterval;
            switch (we.SelectorMethod.ToLower())
            {
                case "id":
                    while(timer < cycles)
                    {
                        IReadOnlyList<IWebElement> ElementsListID = WebDriver.FindElements(By.Id(we.Selector));
                        foreach (IWebElement element in ElementsListID)
                        {
                            we.AllMatchingResults.Add(element);
                        }
                        we.CountMatchingElements();
                        if (we.AmountElements > 0)
                        {
                            isDisplayed = true;
                            break;
                        }
                        else
                        {
                            timer = timer + 1;
                        }
                        Thread.Sleep(milisecondsInterval);
                    }
                    break;
                case "class":
                    while (timer < cycles)
                    {
                        IReadOnlyList<IWebElement> ElementsListID = WebDriver.FindElements(By.ClassName(we.Selector));
                        foreach (IWebElement element in ElementsListID)
                        {
                            we.AllMatchingResults.Add(element);
                        }
                        we.CountMatchingElements();
                        if (we.AmountElements > 0)
                        {
                            isDisplayed = true;
                            break;
                        }
                        else
                        {
                            timer = timer + 1;
                        }
                        Thread.Sleep(milisecondsInterval);
                    }
                    break;
                case "name":
                    while (timer < cycles)
                    {
                        IReadOnlyList<IWebElement> ElementsListID = WebDriver.FindElements(By.Name(we.Selector));
                        foreach (IWebElement element in ElementsListID)
                        {
                            we.AllMatchingResults.Add(element);
                        }
                        we.CountMatchingElements();
                        if (we.AmountElements > 0)
                        {
                            isDisplayed = true;
                            break;
                        }
                        else
                        {
                            timer = timer + 1;
                        }
                        Thread.Sleep(milisecondsInterval);
                    }
                    break;
                case "css":
                    while (timer < cycles)
                    {
                        IReadOnlyList<IWebElement> ElementsListID = WebDriver.FindElements(By.CssSelector(we.Selector));
                        foreach (IWebElement element in ElementsListID)
                        {
                            we.AllMatchingResults.Add(element);
                        }
                        we.CountMatchingElements();
                        if (we.AmountElements > 0)
                        {
                            isDisplayed = true;
                            break;
                        }
                        else
                        {
                            timer = timer + 1;
                        }
                        Thread.Sleep(milisecondsInterval);
                    }
                    break;
                case "xpath":
                    while (timer < cycles)
                    {
                        IReadOnlyList<IWebElement> ElementsListID = WebDriver.FindElements(By.XPath(we.Selector));
                        foreach (IWebElement element in ElementsListID)
                        {
                            we.AllMatchingResults.Add(element);
                        }
                        we.CountMatchingElements();
                        if (we.AmountElements > 0)
                        {
                            isDisplayed = true;
                            break;
                        }
                        else
                        {
                            timer = timer + 1;
                        }
                        Thread.Sleep(milisecondsInterval);
                    }
                    break;
                case "linktext":
                    while (timer < cycles)
                    {
                        IReadOnlyList<IWebElement> ElementsListID = WebDriver.FindElements(By.LinkText(we.Selector));
                        foreach (IWebElement element in ElementsListID)
                        {
                            we.AllMatchingResults.Add(element);
                        }
                        we.CountMatchingElements();
                        if (we.AmountElements > 0)
                        {
                            isDisplayed = true;
                            break;
                        }
                        else
                        {
                            timer = timer + 1;
                        }
                        Thread.Sleep(milisecondsInterval);
                    }
                    break;
            }
            we.CountMatchingElements();
            testElement = we;
            return isDisplayed;
        }

    }


}

