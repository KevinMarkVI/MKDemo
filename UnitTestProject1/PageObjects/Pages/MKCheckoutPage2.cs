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
    class MKCheckoutPage2 : PageBase
    {
        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_MerchandiseTotal")]
        public IWebElement summaryMerchandiseTotal { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_ProcessingFeeTotal")]
        public IWebElement summaryProcessingFee { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_ShippingTotal")]
        public IWebElement summaryShippingTotal { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_TaxTotal")]
        public IWebElement summaryTaxTotal { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_OrderTotals_OrderTotal")]
        public IWebElement summaryTotal { get; set; }

        [FindsBy(How = How.ClassName, Using = "CartHeader")]
        public IWebElement summaryShippedTo { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_ShoppingCartDetail1_ProductHyperLink0")]
        public IWebElement summaryProductDescription { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_Payment1_ExpirationMonthDropDownList")]
        public IWebElement paymentMonthSelector { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_Payment1_CreditCardTypeDropDownList")]
        public IWebElement paymentTypeSelector { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_Payment1_CreditCardNumberTextBox")]
        public IWebElement cardNumberInput { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_Payment1_ExpirationYearDropDownList")]
        public IWebElement paymentYearSelector { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_Payment1_CreditCardSecurityCodeTextBox")]
        public IWebElement securityCodeInput { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_Payment1_SubmitOrder")]
        public IWebElement submitOrderButton { get; set; }

        public MKCheckoutPage2(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.title = this.webDriver.Title;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void completePaymentInfo()
        {
            SelectElement paymentType = new SelectElement(this.paymentTypeSelector);
            paymentType.SelectByValue("058b6f07-ac45-46f4-90ce-3f2dd760750e");
            System.Threading.Thread.Sleep(1000);

            this.cardNumberInput.SendKeys("4111111111111111");

            SelectElement paymentMonth = new SelectElement(this.paymentMonthSelector);
            paymentMonth.SelectByValue("02");

            SelectElement paymentYear = new SelectElement(this.paymentYearSelector);
            paymentYear.SelectByValue("2016");

            this.securityCodeInput.SendKeys("156");

        }
    }
}
