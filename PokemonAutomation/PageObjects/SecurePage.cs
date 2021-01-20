using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PageObjects
{
    public class SecurePage
    {
        WebElement messageLabel = new WebElement("flash","id");
        WebElement logoutButton = new WebElement("i[class='icon-2x icon-signout']", "css");

        public IWebDriver _driver;

        public SecurePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public WebElement ClicLogoutButton()
        {
            WebPage genericPage = new WebPage(_driver);
            logoutButton = genericPage.ClickElement(logoutButton);
            return logoutButton;
        }

        public string GetLabelMessageText()
        {
            messageLabel.SearchForThisElement(_driver);
            string text = null;
            if (messageLabel.AmountElements == 1)
            {
                text = messageLabel.AllMatchingResults[0].Text;
            }
            return text;
        }

    }
}
