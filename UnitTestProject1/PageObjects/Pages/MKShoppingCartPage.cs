using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.PageObjects.Pages
{
    class MKShoppingCartPage : PageBase
    {

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_ShippingOptions1_MerchTotalAmountLabel")]
        public IWebElement merchandiseTotal { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_ShippingOptions1_ProcessingFeeAmountLabel")]
        public IWebElement processing { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_ShippingOptions1_SubtotalAmountLabel")]
        public IWebElement subTotal { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_TopCheckoutButton")]
        public IWebElement checkoutButton { get; set; }



        public MKShoppingCartPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.title = this.webDriver.Title;
            PageFactory.InitElements(this.webDriver, this);
        }

    }
}
