using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.PageObjects.Pages
{
    class MKCheckoutPage2 : PageBase
    {
        public MKCheckoutPage2(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            if (!this.webDriver.Url.Contains("2"))
            {
                throw new InvalidElementStateException("This is not the correct page");
            }
            this.title = this.webDriver.Title;
            PageFactory.InitElements(this.webDriver, this);
        }
    }
}
