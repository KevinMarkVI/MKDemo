using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.PageObjects.Pages
{
    class MKLoginPage : PageBase 
    {

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_GuestCheckoutButton")]
        public IWebElement checkoutAsGuestButton { get; set; }

        public MKLoginPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            if (!this.webDriver.Url.Contains("login"))
            {
                throw new InvalidElementStateException("This is not the correct page");
            }
            this.title = this.webDriver.Title;
            PageFactory.InitElements(this.webDriver, this);
        }
    }
}
