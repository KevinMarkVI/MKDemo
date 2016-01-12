using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace UnitTestProject1
{
    [Binding]
    public class GuineaPigSteps
    {
        public IWebDriver driver = (IWebDriver)ScenarioContext.Current["driver"];

        [Given(@"I am on the Guinea Pig Website")]
        public void GivenIAmOnTheGuineaPigWebsite()
        {
            driver.Navigate().GoToUrl("https://saucelabs.com/test/guinea-pig");
        }

        [When(@"I check the title")]
        public void WhenICheckTheTitle()
        {
            string title = driver.Title;
            Console.WriteLine(title);
        }

        [Then(@"the title should be what I expect")]
        public void ThenTheTitleShouldBeWhatIExpect()
        {
            Assert.AreEqual(driver.Title, "I am a page title - Sauce Labs");
        }
    }
}