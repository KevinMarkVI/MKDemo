using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.PageObjects.Pages
{
    class MKHomePage : PageBase
    {

        public static readonly Uri URL = new Uri("https://www.mileskimball.com");

        [FindsBy(How = How.Id, Using = "mf234")]
        public IWebElement closePopup { get; set; }

        [FindsBy(How = How.Id, Using = "sli_search_1")]
        public IWebElement searchInput { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_btnSearch")]
        public IWebElement searchInputSubmitButton { get; set; }

        public MKHomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            if (!this.webDriver.Url.Contains(URL.ToString()))
            {
                throw new InvalidElementStateException("This is not the MKHomePage page");
            }
            this.title = this.webDriver.Title;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void search(string SKU)
        {
            this.searchInput.SendKeys(SKU);
            this.searchInputSubmitButton.Click();
        }

    }
}