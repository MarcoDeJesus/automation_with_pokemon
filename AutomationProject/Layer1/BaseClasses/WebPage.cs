using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;


namespace PageObjects
{
    public class WebPage
    {
        public static IWebDriver WebDriver { get; set; }
        public static int ImplicitWaitSeconds = 0;
        public static int TimeOutSeconds = 0;


        public static void OpenWebBrowser(string wb)
        {
            switch (wb)
            {
                case "gc":
                    WebDriver = new ChromeDriver();
                    WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                    WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    TimeOutSeconds = 30;
                    ImplicitWaitSeconds = 5;
                    break;
                case "ff":
                    WebDriver = new FirefoxDriver();
                    WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                    WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    TimeOutSeconds = 30;
                    ImplicitWaitSeconds = 5;
                    break;
            }
        }


        public static void LoadWebPage(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public static void MaximizeWindow()
        {
            WebDriver.Manage().Window.Maximize();
        }


        public static void CloseBrowser()
        {
            WebDriver.Close();
        }


        public static void MinimizeWindow()
        {
            WebDriver.Manage().Window.Minimize();
        }


        public static void RefreshBrowser()
        {
            WebDriver.Navigate().Refresh();
        }


        public static void UpdateImplicitWait(int seconds)
        {
            ImplicitWaitSeconds = seconds;
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }


        public static void UpdateTimeOut(int seconds)
        {
            TimeOutSeconds = seconds;
            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(seconds);
        }

        public static WebElement ClickElement(WebElement we)
        {
            we.SearchForThisElement();
            if (we.AllMatchingResults.Count == 1)
            {
                we.AllMatchingResults[0].Click();
            }
            return we;
        }


        public static WebElement EnterTextInElement(WebElement we, string text)
        {
            we.SearchForThisElement();
            if (we.AllMatchingResults.Count == 1)
            {
                we.AllMatchingResults[0].SendKeys(text);
            }
            return we;
        }


        public static WebElement ClearTextBoxText(WebElement we)
        {
            we.SearchForThisElement();
            if (we.AllMatchingResults.Count == 1)
            {
                we.AllMatchingResults[0].SendKeys(Keys.Control + "a");
                we.AllMatchingResults[0].SendKeys(Keys.Delete);
            }
            return we;
        }

        public static Actions NewActionsObject()
        {
            Actions actions = new Actions(WebDriver);
            return actions;
        }


    }


}

