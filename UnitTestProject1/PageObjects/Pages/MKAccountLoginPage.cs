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
    class MKAccountLoginPage : PageBase
    {
        public static readonly Uri URL = new Uri("https://www.mileskimball.com/mileskimball/account/");

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_txtLoginEmailAddress")]
        public IWebElement emailInput { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_txtLoginPassword")]
        public IWebElement passwordInput { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_btnLogin")]
        public IWebElement loginButton { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphBody_lblLoginError")]
        public IWebElement errorMessage { get; set; }

        public MKAccountLoginPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.title = this.webDriver.Title;
            PageFactory.InitElements(this.webDriver, this);
        }

    }
}
