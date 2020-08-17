using APIModules;
using AutomationProject.Layer2.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjects;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using UIModules;

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
