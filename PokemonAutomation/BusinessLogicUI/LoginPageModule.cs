using OpenQA.Selenium;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAutomation.BusinessLogicUI
{
    public class LoginPageModule
    {
        public IWebDriver CurrentDriver;
        private string WebBrowser;


        public LoginPageModule(IWebDriver driver)
        {
            CurrentDriver = driver;
        }

        public LoginPageModule()
        {
        }

        public void GoToThisPage()
        {
            CurrentDriver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
        }

        public void TheTestUserProvidesTheseCredentials(string username, string password)
        {
            LoginPage lp = new LoginPage(CurrentDriver);
            lp.EnterTextInUsernameInput(username);
            lp.EnterTextInPasswordInput(password);
        }

        public void TheUserClicksTheLoginButton()
        {
            LoginPage lp = new LoginPage(CurrentDriver);
            lp.ClickLoginButton();
        }

        public string RetrieveLabelErrorMessage()
        {
            LoginPage lp = new LoginPage(CurrentDriver);
            string message = lp.GetErrorLabelMessageText();
            return message;
        }

        public string RetrievePageTitle()
        {
            LoginPage lp = new LoginPage(CurrentDriver);
            string title = lp.ReturnPageTitle();
            return title;
        }
    }
}
