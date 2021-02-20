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


        public void UpdateImplicitWait(int seconds)
        {
            ImplicitWaitSeconds = seconds;
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }


        public void UpdateTimeOut(int seconds)
        {
            TimeOutSeconds = seconds;
            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(seconds);
        }

        public WebElement ClickElement(WebElement we)
        {
            we.SearchForThisElement(WebDriver);
            if (we.AmountElements == 1)
            {
                IWebElement Result = we.ReturnTheIWebElementInPosition(1);
                Result.Click();
            }
            return we;
        }


        public WebElement EnterTextInElement(WebElement we, string text)
        {
            we.SearchForThisElement(WebDriver);
            if (we.AmountElements == 1)
            {
                IWebElement Result = we.ReturnTheIWebElementInPosition(1);
                Result.SendKeys(text);
            }
            return we;
        }


        public WebElement ClearTextBoxText(WebElement we)
        {
            we.SearchForThisElement(WebDriver);
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


        public bool SearchUntilElementIsPresent(WebElement we)
        {
            we.AllMatchingResults.Clear();
            int timer = 0;
            WebPage genericPage = new WebPage(WebDriver);
            bool isDisplayed = false;
            int cycles = explicitWait * 1000 / milisecondsInterval;
            switch (we.SelectorMethod.ToLower())
            {
                case "id":
                    while(timer < cycles)
                    {
                        IReadOnlyList<IWebElement> ElementsListID = genericPage.WebDriver.FindElements(By.Id(we.Selector));
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
                        IReadOnlyList<IWebElement> ElementsListID = genericPage.WebDriver.FindElements(By.ClassName(we.Selector));
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
                        IReadOnlyList<IWebElement> ElementsListID = genericPage.WebDriver.FindElements(By.Name(we.Selector));
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
                        IReadOnlyList<IWebElement> ElementsListID = genericPage.WebDriver.FindElements(By.CssSelector(we.Selector));
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
                        IReadOnlyList<IWebElement> ElementsListID = genericPage.WebDriver.FindElements(By.XPath(we.Selector));
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
                        IReadOnlyList<IWebElement> ElementsListID = genericPage.WebDriver.FindElements(By.LinkText(we.Selector));
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

