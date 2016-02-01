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
    class MKKidsPage : PageBase
    {


        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphBody_rptSubCategoryList_ctl01_liExpand")]
        public IWebElement schoolSupplies { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "pencils")]
        public IWebElement pencilsAndPencilCases { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphBody_cpInternalMaster_ddlItemsPerPageTop")]
        public IWebElement itemsPerPageSelector { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphBody_cpInternalMaster_rptDisplayItems_ctl01_productThumbnail_hplDisplayItem")]
        public IWebElement musicalNotePencilsLink { get; set; }

        public MKKidsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            this.title = this.webDriver.Title;
            PageFactory.InitElements(this.webDriver, this);
        }


    }
}
