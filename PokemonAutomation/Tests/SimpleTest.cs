using Features;
using NUnit.Framework;
using PageObjects;
using PokemonAutomation.BusinessLogicUI;

namespace PokemonAutomation.Tests
{
    [TestFixture]
    public class SimpleTest
    {
        [Test]
        [TestCase("invalidUsername", "invalidPassword", "Your username is invalid!\r\n×")]
        [TestCase("invalidUsername", "SuperSecretPassword!", "Your username is invalid!\r\n×")]
        [TestCase("tomsmith", "wronmgpassword", "Your password is invalid!\r\n×")]
        public void LoginWithInvalidCredentialsShouldDisplaysAnError(string username, string password, string error)
        {
            WebPage genericBrowser = new WebPage();
            genericBrowser.OpenBrowser("gc");
            genericBrowser.MaximizeWindow();
            LoginPageModule lpm = new LoginPageModule(genericBrowser.WebDriver);
            lpm.GoToThisPage();
            lpm.TheTestUserProvidesTheseCredentials(username, password);
            lpm.TheUserClicksTheLoginButton();
            string errorText = lpm.RetrieveLabelErrorMessage();
            Assert.True(error.Equals(errorText));
            genericBrowser.CloseBrowser();
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            WebPage genericBrowser = new WebPage();
            genericBrowser.OpenBrowser("gc");
            genericBrowser.MaximizeWindow();
            LoginPageModule lpm = new LoginPageModule(genericBrowser.WebDriver);
            lpm.GoToThisPage();
            lpm.TheTestUserProvidesTheseCredentials("tomsmith", "SuperSecretPassword!");
            lpm.TheUserClicksTheLoginButton();
            SecurePage sp = new SecurePage(genericBrowser.WebDriver);
            string pageTitle = genericBrowser.WebDriver.Title;
            Assert.True("The Internet".Equals(pageTitle));
            genericBrowser.CloseBrowser();
        }

        [Test]
        public void LogoutShouldRedirectUserToLoginScreen()
        {
            WebPage genericBrowser = new WebPage();
            genericBrowser.OpenBrowser("gc");
            genericBrowser.MaximizeWindow();
            LoginPageModule lpm = new LoginPageModule(genericBrowser.WebDriver);
            lpm.GoToThisPage();
            lpm.TheTestUserProvidesTheseCredentials("tomsmith", "SuperSecretPassword!");
            lpm.TheUserClicksTheLoginButton();
            SecurePage sp = new SecurePage(genericBrowser.WebDriver);
            sp.ClicLogoutButton();
            lpm.CurrentDriver = sp._driver;
            string pageTitle = lpm.RetrievePageTitle();
            Assert.True("The Internet".Equals(pageTitle));
            genericBrowser.CloseBrowser();
        }


    }
}
