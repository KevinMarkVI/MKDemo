using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.PageObjects.Pages
{
    class MKProductPage : PageBase
    {

        public static readonly Uri URL = new Uri("http://www.mileskimball.com/buy-paua-shamrock-earrings-340665");

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphBody_cpInternalMaster_rptDisplayItems_ctl00_btnAddToCart")]
        public IWebElement addToCartButton { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_AddToCartControl_btnCheckout")]
        public IWebElement popupViewCartCheckoutButton { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_AddToCartControl_rptCartSummary_ctl00_lblProductId")]
        public IWebElement popupProductNumber { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_AddToCartControl_rptCartSummary_ctl00_lblPrice")]
        public IWebElement popupProductPrice { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_AddToCartControl_rptCartSummary_ctl00_hlkProductAdded")]
        public IWebElement popupProductDescription { get; set; }

        [FindsBy(How = How.Id, Using = "mf234")]
        public IWebElement closePopup { get; set; }

        public MKProductPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            if (!this.webDriver.Url.Contains(URL.ToString()))
            {
                throw new InvalidElementStateException("This is not the correct page");
            }
            this.title = this.webDriver.Title;
            PageFactory.InitElements(this.webDriver, this);
        }

    }
}
