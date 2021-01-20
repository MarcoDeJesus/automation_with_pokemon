using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PageObjects
{
    public class LoginPage
    {
        WebElement errorLabel = new WebElement("flash", "id");
        WebElement usernameInput = new WebElement("username", "id");
        WebElement passwordInput = new WebElement("password", "id");
        WebElement loginButton = new WebElement("i[class='fa fa-2x fa-sign-in']","css");

        public IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public WebElement ClickLoginButton()
        {
            WebPage genericPage = new WebPage(_driver);
            loginButton = genericPage.ClickElement(loginButton);
            return loginButton;
        }

        public WebElement EnterTextInUsernameInput(string text)
        {
            WebPage genericPage = new WebPage(_driver);
            usernameInput = genericPage.EnterTextInElement(usernameInput, text);
            return usernameInput;
        }

        public WebElement EnterTextInPasswordInput(string text)
        {
            WebPage genericPage = new WebPage(_driver);
            passwordInput = genericPage.EnterTextInElement(passwordInput, text);
            return passwordInput;
        }

        public string GetErrorLabelMessageText()
        {
            errorLabel.SearchForThisElement(_driver);
            string text = null;
            if (errorLabel.AmountElements == 1)
            {
                text = errorLabel.AllMatchingResults[0].Text;
            }
            return text;
        }

        public string ReturnPageTitle()
        {
            string title = _driver.Title;
            return title;
        }

    }
}
