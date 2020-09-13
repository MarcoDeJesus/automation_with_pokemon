using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
namespace PageObjects

{
    public class WebPage
    {
        public static IWebDriver WebDriver { get; set; }
        public static int ImplicitWaitSeconds = 0;
        public static int TimeOutSeconds = 0;


        public static void OpenBrowser(string browser)
        {
            switch (browser)
            {
                case "gc":
                    WebDriver = new ChromeDriver();
                    WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                    WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    break;
                case "ff":
                    WebDriver = new FirefoxDriver();
                    WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                    WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
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
            if (we.AmountElements == 1)
            {
                IWebElement Result = we.ReturnTheIWebElementInPosition(1);
                Result.Click();
            }
            return we;
        }


        public static WebElement EnterTextInElement(WebElement we, string text)
        {
            we.SearchForThisElement();
            if (we.AmountElements == 1)
            {
                IWebElement Result = we.ReturnTheIWebElementInPosition(1);
                Result.SendKeys(text);
            }
            return we;
        }


        public static WebElement ClearTextBoxText(WebElement we)
        {
            we.SearchForThisElement();
            if (we.AmountElements == 1)
            {
                IWebElement Result = we.ReturnTheIWebElementInPosition(1);
                Result.SendKeys(Keys.Control + "a");
                Result.SendKeys(Keys.Delete);
            }
            return we;
        }
    }

}

