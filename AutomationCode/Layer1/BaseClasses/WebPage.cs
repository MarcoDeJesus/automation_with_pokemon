using OpenQA.Selenium;
using System;
namespace PageObjects

{
    public class WebPage
    {
        public static IWebDriver WebDriver { get; set; }
        public int ImplicitWaitSeconds = 0;
        public int TimeOutSeconds = 0;

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


    }


}

