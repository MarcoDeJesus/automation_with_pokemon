using PageObjects;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace TestsSteps
{
    [Binding]
    public static class GenericSteps
    {
        public static bool isWebTest = false;
        public static Dictionary<string, dynamic> TestContextData = new Dictionary<string, dynamic>();

        [AfterScenario]
        public static void CloseBrowser()        
        {
            if (isWebTest == true)
            {
                WebPage.WebDriver.Close();
            }
        }


        [BeforeScenario]
        public static void ClearStaticVariables()
        {
            if (isWebTest == true)
            {
                TestContextData.Clear();
            }
        }

    }
}
