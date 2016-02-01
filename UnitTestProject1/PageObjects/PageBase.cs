using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace UnitTestProject1.PageObjects
{
    class PageBase
    {
        protected IWebDriver webDriver;

        public string freeShippingPopUpId = "mf234";

        public string title { get; protected set; }

        public void closeFreeShippingPopup()
        {
            try
            {
                webDriver.FindElement(By.Id(this.freeShippingPopUpId)).Click();
            }
            catch (NoSuchElementException)
            {
            }
        }

    }

    
}
