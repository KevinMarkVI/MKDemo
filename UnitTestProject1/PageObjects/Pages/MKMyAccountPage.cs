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
    class MKMyAccountPage : PageBase
    {
        [FindsBy(How = How.Id, Using = "ctl00_cphBody_lblFirstNameBanner")]
        public IWebElement accountFirstNameBanner { get; set; }

        public MKMyAccountPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.title = this.webDriver.Title;
            PageFactory.InitElements(this.webDriver, this);
        }

    }
}
