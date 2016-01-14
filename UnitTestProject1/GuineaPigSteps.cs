using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1.PageObjects.Pages;
using OpenQA.Selenium.Support.UI;



namespace UnitTestProject1
{
    [Binding]
    public class GuineaPigSteps
    {
        public static IWebDriver driver = (IWebDriver)ScenarioContext.Current["driver"];
        public WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        [Given(@"I am on the Guinea Pig Website")]
        public void GivenIAmOnTheGuineaPigWebsite()
        {
            //driver.Navigate().GoToUrl("https://saucelabs.com/test/guinea-pig");
            driver.Navigate().GoToUrl("https://www.mileskimball.com/buy-paua-shamrock-earrings-340665");
        }

        [When(@"I check the title")]
        public void WhenICheckTheTitle()
        {
            //string title = driver.Title;
            IWebElement popUp = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("mf234"));
            });
            popUp.Click();
        }

        [Then(@"the title should be what I expect")]
        public void ThenTheTitleShouldBeWhatIExpect()
        {
            //Assert.AreEqual(driver.Title, "I am a page title - Sauce Labs");
            IWebElement homepage = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("ctl00_ctl00_cphBody_cpInternalMaster_rptDisplayItems_ctl00_btnAddToCart"));
            });
            Assert.IsTrue(homepage.Displayed);
            homepage.Click();
        }
    }
}