using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
namespace PageObjects

{
    public class WebPage
    {
        public IWebDriver WebDriver { get; set; }
        public int ImplicitWaitSeconds = 0;
        public int TimeOutSeconds = 0;


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


    }


}

