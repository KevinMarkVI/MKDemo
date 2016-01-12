using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1.PageObjects.Pages
{
    class MKCheckoutPage1 : PageBase
    {

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_add_BAFirstNameTextBox")]
        public IWebElement firstNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_add_BALastNameTextBox")]
        public IWebElement lastNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_add_BAAddress1TextBox")]
        public IWebElement addressInput { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_add_BACityTextBox")]
        public IWebElement cityInput { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_add_BAStateDDL")]
        public IWebElement stateSelector { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_add_BAZipTextBox")]
        public IWebElement zipCodeInput { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_add_BADayTimeTextBox")]
        public IWebElement phoneInput { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_add_BAEmailTextBox")]
        public IWebElement emailInput { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_add_BAConfirmEmailTextBox")]
        public IWebElement confirmEmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_add_PaymentReviewButton")]
        public IWebElement proceedToPaymentAndReviewButton { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_add_SHAlsoShippingAddressRadioButton")]
        public IWebElement shipToBillingAddressRadioButton { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_add_ctl00_1")]
        public IWebElement giftRadioButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "order-summary-amount")]
        public IWebElement orderSummaryItems { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_MerchandiseTotal")]
        public IWebElement orderSummaryMerchandiseTotal { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_ProcessingFeeTotal")]
        public IWebElement orderSummaryProcessingFee { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_ShippingTotal")]
        public IWebElement orderSummaryShippingAndHandling { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_OrderTotal")]
        public IWebElement orderSummaryTotal { get; set; }

        public MKCheckoutPage1(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            if (!this.webDriver.Url.ToString().Contains("checkoutstep1"))
            {
                throw new InvalidElementStateException("This is not the correct page");
            }
            this.title = this.webDriver.Title;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void completeForm()
        {
            this.firstNameInput.SendKeys("Test");
            this.lastNameInput.SendKeys("Automation");
            this.addressInput.SendKeys("118 E Bufflehead Dr");
            this.cityInput.SendKeys("Sweetwater");
            SelectElement stateOptions = new SelectElement(this.stateSelector);
            stateOptions.SelectByValue("TN");
            this.zipCodeInput.SendKeys("37874");
            this.phoneInput.SendKeys("4235551234");
            this.emailInput.SendKeys("testorders@mileskimball.com");
            this.confirmEmailInput.SendKeys("testorders@mileskimball.com");
        }

    }
}
