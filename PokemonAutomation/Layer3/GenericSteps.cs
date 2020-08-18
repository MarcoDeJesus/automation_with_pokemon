using PageObjects;
using TechTalk.SpecFlow;

namespace TestsSteps
{
    [Binding]
    public static class GenericSteps
    {
        public static bool isWebTest = false;

        [AfterScenario]
        public static void CloseBrowser()        
        {
            if (isWebTest == true)
            {
                WebPage.WebDriver.Close();
            }
        }

    }
}
