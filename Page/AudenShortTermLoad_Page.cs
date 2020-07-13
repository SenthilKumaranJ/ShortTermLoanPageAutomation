using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AudenShortTermLoan.Hooks;
using OpenQA.Selenium.Interactions;

namespace AudenShortTermLoan.Page
{
    public class AudenShortTermLoadPage
    {
        //for using wait functionality using selenium extras
        private readonly WebDriverWait wait;
        private string MinSliderValue;
        private string LoanAmountSliderValue;
        private string NextFridayDayValue;

        public IWebDriver WebDriver { get; set; }
        public AudenShortTermLoadPage(IWebDriver webDriver)
        {
            WebDriver = Hook.webDriver;
            
        }
    

        //Page Elements from ShortTermLoan Page. 
        public IWebElement LoanAmountSliderElementCSS => WebDriver.FindElement(By.CssSelector(".loan-amount__range-slider__input"));
        private readonly IWebElement LoanAmountSlider;
        public IWebElement LoanAmoutSliderValueElementCSS => WebDriver.FindElement(By.CssSelector(".loan-amount__header__amount [data-testid=\"loan-amount-value\"]"));
        public IWebElement RepaymentDaySunElementCss => WebDriver.FindElement(By.CssSelector(".date-selector__date[name=\"day\"][value=\"1\"]"));
        public IWebElement RepaymentDaySatElementCSS => WebDriver.FindElement(By.CssSelector(".date-selector__date[name=\"day\"][value=\"2\"]"));
        public IWebElement EligibiltyButtonElementCss => WebDriver.FindElement(By.CssSelector(".loan-calculator__apply[type=\"button\"]"));
        public IWebElement CalculatedLoanAmountElementCss => WebDriver.FindElement(By.CssSelector(".loan-summary__column__amount__value"));
        public IWebElement FirstRepaymentDayElementCss => WebDriver.FindElement(By.CssSelector("loan-schedule__tab__panel__detail__tag__label"));

        //below is based on suggestion from stack overflow
        
        public DateTime firstRepaymentDayValue => DateTime.ParseExact(FirstRepaymentDayElementCss.GetAttribute("value"), "ddd", System.Globalization.CultureInfo.InvariantCulture);


        //Launch Site function
        public void LaunchSite(String url) => WebDriver.Navigate().GoToUrl(url);
        //There is no need to click on eligibility button in the solution. Diag purpose only
        public void ClickEligibiltyButton() => EligibiltyButtonElementCss.Click();
        //Capture amount displayed on top of the slider
        public string GetSliderValue()
        {
            LoanAmountSliderValue = LoanAmoutSliderValueElementCSS.GetAttribute("value");
            return LoanAmountSliderValue;
        }

        public string GetSliderMinValue => LoanAmountSliderElementCSS.GetAttribute("min");
        public string GetSliderMaxValue => LoanAmountSliderElementCSS.GetAttribute("max");

        //public DateTime FirstRepaymentDayValue { get => firstRepaymentDayValue; set => firstRepaymentDayValue = value; }
        //public DateTime FirstRepaymentDayValue1 { get => firstRepaymentDayValue; set => firstRepaymentDayValue = value; }

        //Click element. Can improve this with wait for visible check
        public void ClickElement(IWebElement element) => element.Click();
        //Wait helper functions from Selenium Extras
        public void ElementToBeClickable(IWebElement element) => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        //public void ElementIsVisible(IWebElement element)=> wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));

        public void SetSlidermin()
        {
            ElementToBeClickable(LoanAmoutSliderValueElementCSS);
            LoanAmoutSliderValueElementCSS.Click();
            var act = new Actions(WebDriver);
            //Improvement Idea: should combine this with the max and random value for slider and put some error handling
            act.DragAndDropToOffset(LoanAmoutSliderValueElementCSS, 0, 0);
        }
        public void SetSliderMax()
        {
            ElementToBeClickable(LoanAmoutSliderValueElementCSS);
            LoanAmoutSliderValueElementCSS.Click();
            var act = new Actions(WebDriver);
            //Improvement Idea: should combine this with the max and random value for slider and put some error handling
            act.DragAndDropToOffset(LoanAmoutSliderValueElementCSS, 350, 340);
        }

        public void SetSliderRandom()
        {
            ElementToBeClickable(LoanAmoutSliderValueElementCSS);
            LoanAmoutSliderValueElementCSS.Click();
            var act = new Actions(WebDriver);
            //Improvement Idea: should combine this with the max and random value for slider and put some error handling
            act.DragAndDropToOffset(LoanAmoutSliderValueElementCSS, 200, 340);
        }


        public void SelectSundayPaymentDay()
        {
            //get today's date time
            var today = DateTime.Now;
            // calculate next sunday day value//needed help on this from stack exchange etc
            var nextSundayDayValue = today.AddDays(14 - (int)today.DayOfWeek).ToString("dd");
            // Clicking on Sunday Day value calculated above by creating a dynamic object by passing day value into CSS selector
            var PaymentDate = WebDriver.FindElement(By.CssSelector($"[id='monthly'][value='{nextSundayDayValue}']"));
            ClickElement(PaymentDate);
        }
        public void SelectSaturdayPaymentDay()
        {
            //get today's date time
            var today = DateTime.Now;
            // calculate next Saturday day value//needed help on this from stack exchange etc
            var nextSaturdayDayValue = today.AddDays(14 - (int)today.DayOfWeek).ToString("dd");
            // Clicking on Sunday Day value calculated above by creating a dynamic object by passing day value into CSS selector
            var PaymentDate = WebDriver.FindElement(By.CssSelector($"[id='monthly'][value='{nextSaturdayDayValue}']"));
            ClickElement(PaymentDate);
        }



    }
}
