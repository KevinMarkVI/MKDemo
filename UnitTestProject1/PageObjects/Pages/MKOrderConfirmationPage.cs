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
    class MKOrderConfirmationPage : PageBase
    {

        [FindsBy(How = How.Id, Using = "gts-g-clx")]
        public IWebElement googlePopupWindow { get; set; }

        [FindsBy(How = How.Id, Using = "TTSubWindowClose")]
        public IWebElement surveyPopupWindow { get; set; }

        [FindsBy(How = How.Id, Using = "FreeShippingPopupClose")]
        public IWebElement freeShippingPopupWindow { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_BillingAddress")]
        public IWebElement confirmationBillingAddress { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_PaymentMethod")]
        public IWebElement confirmationPaymentMethod { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_ShippingMethod")]
        public IWebElement confirmationShipMethod { get; set; }

        [FindsBy(How = How.Id, Using = "")]
        public IWebElement confirmation { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_MerchandiseTotal")]
        public IWebElement confirmationMerchandiseTotal { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_ProcessingFeeTotal")]
        public IWebElement confirmationProcessingFee { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_ShippingTotal")]
        public IWebElement confirmationShippingTotal { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_TaxTotal")]
        public IWebElement confirmationTaxTotal { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_OrderTotal")]
        public IWebElement confirmationOrderTotal { get; set; }

        public MKOrderConfirmationPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.title = this.webDriver.Title;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void closePopupWindows()
        {
            this.googlePopupWindow.Click();
            this.surveyPopupWindow.Click();
            this.freeShippingPopupWindow.Click();
            System.Threading.Thread.Sleep(5000);

        }
    }
}
