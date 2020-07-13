using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AudenShortTermLoan.Hooks
{
    [Binding]
    public class Hook
    {
        public static IWebDriver webDriver;
        [BeforeScenario]
        public void BeforeScenario()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            //Added this for the driver to wait 10 seconds before it declares that it cannot find the object
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            webDriver.Quit();
            
        }
    }
}
