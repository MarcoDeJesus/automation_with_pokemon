using OpenQA.Selenium;
using System;
namespace PageObjects

{
    public class WebPage
    {
        public static IWebDriver WebDriver { get; set; }
        public static int ImplicitWaitSeconds = 0;
        public static int TimeOutSeconds = 0;

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


    }


}

