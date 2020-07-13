using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AudenShortTermLoan.Step
{
    [Binding]
    public sealed class AudenShortTermLoan_Steps
    {
        //Keep it simple for one page
        Page.AudenShortTermLoadPage AudenShortTermLoadPage = null;
        //Step Definitions
        [Given(@"I launch the ShortTermLoan Page")]
        public void GivenILaunchTheShortTermLoanPage()
        {
            //IWebDriver webDriver = new ChromeDriver();
            //webDriver.Navigate().GoToUrl("https://www.auden.co.uk/credit/shorttermloan");
            //AudenShortTermLoadPage = new Page.AudenShortTermLoadPage(webDriver);
            
            ///More efficient and modular would be to have the entire thing data driven and get url from a config file
            AudenShortTermLoadPage.LaunchSite("https://www.auden.co.uk/credit/shorttermloan");

        }
        [When(@"I set the loan amount slider to minimum")]
        public void WhenISetTheLoanAmountSliderToMinimum()
        {
            AudenShortTermLoadPage.SetSlidermin();
        }

        [Then(@"Minimum loan amount should be £(.*) on the slider value")]
        public void ThenMinimumLoanAmountShouldBeOnTheSliderValue()
        {
            Assert.AreEqual("200", AudenShortTermLoadPage.GetSliderMinValue);
            
        }

        [When(@"I set the loan amount slider to Maximum")]
        public void WhenISetTheLoanAmountSliderToMaximum()
        {
            AudenShortTermLoadPage.SetSliderMax();
        }

        [Then(@"Maximum loan amount should be £(.*) on the slider value")]
        public void ThenMaximumLoanAmountShouldBeOnTheSliderValue()
        {
            Assert.AreEqual("500", AudenShortTermLoadPage.GetSliderMaxValue);
        }

        

        [Then(@"loan slider value should be equal to the calculated loan value")]
        public void ThenLoanSliderValueShouldBeEqualToTheCalculatedLoanValue()
        {
            //can probably try and make this line simple and userfriendly
            Assert.AreEqual(AudenShortTermLoadPage.CalculatedLoanAmountElementCss.Text, AudenShortTermLoadPage.GetSliderValue());
        }

        [When(@"I set the loan amount slider to any value")]
        public void WhenISetTheLoanAmountSliderToAnyValue()
        {
            AudenShortTermLoadPage.SetSliderRandom();
        }

        [When(@"I set the payment date as Sunday")]
        public void WhenISetThePaymentDateAsSunday()
        {
            AudenShortTermLoadPage.SelectSundayPaymentDay();
        }

        [Then(@"First Payment date will be a Friday")]
        public void ThenFirstPaymentDateWillBeAFriday()
        {
            //If I have more time I can research and implement something more intelligent but
            //Right now I am just extracting the "Friday" from the webelement and comparing it
            // constructor implementation is in the page objects code.
            Assert.AreEqual("Fri", AudenShortTermLoadPage.firstRepaymentDayValue);
        }

        [When(@"I set the payment date as Saturday")]
        public void WhenISetThePaymentDateAsSaturday()
        {
            AudenShortTermLoadPage.SelectSaturdayPaymentDay();
        }




    }
}
