using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject1.PageObjects.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
namespace UnitTestProject1
{
    [Binding]
    public class MKAccountLoginErrorTestingSteps
    {
        public static IWebDriver driver = (IWebDriver)ScenarioContext.Current["driver"];
        public WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        [Given(@"I am on the MK Account Login Page")]
        public void GivenIAmOnTheMKAccountLoginPage()
        {
            driver.Navigate().GoToUrl(MKAccountLoginPage.URL);
            MKAccountLoginPage accountLoginPage = new MKAccountLoginPage(driver);
            ScenarioContext.Current["accountLoginPage"] = accountLoginPage;
        }
        
        [When(@"I Click on the My Account Link")]
        public void WhenIClickOnTheMyAccountLink()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            IWebElement myAccountLoginLink = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(homePage.myAccountHeaderButton.GetAttribute("id"))));
            myAccountLoginLink.Click();
            MKAccountLoginPage accountLoginPage = new MKAccountLoginPage(driver);
            IWebElement myAccountLoginPageElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(accountLoginPage.emailInput.GetAttribute("id"))));
            Assert.IsTrue(myAccountLoginPageElement.Displayed);
            ScenarioContext.Current["accountLoginPage"] = accountLoginPage;
        }

        [Given(@"I check for the Free Shipping popup on the account login page")]
        public void GivenICheckForPopUpHomePage()
        {
            MKAccountLoginPage accountLoginPage = (MKAccountLoginPage)ScenarioContext.Current["accountLoginPage"];
            accountLoginPage.closeFreeShippingPopup();
            ScenarioContext.Current["accountLoginPage"] = accountLoginPage;
        }

        [When(@"I enter the email address '(.*)' and the password '(.*)'")]
        public void WhenIEnterTheEmailAddressAndThePassword(string email, string password)
        {
            MKAccountLoginPage accountLoginPage = (MKAccountLoginPage)ScenarioContext.Current["accountLoginPage"];
            accountLoginPage.emailInput.SendKeys(email);
            accountLoginPage.passwordInput.SendKeys(password);
            accountLoginPage.loginButton.Click();
            ScenarioContext.Current["accountLoginPage"] = accountLoginPage;
        }
        
        [Then(@"I should be on the Account Login Page")]
        public void ThenIShouldBeOnTheAccountPage()
        {
            MKAccountLoginPage accountLoginPage = (MKAccountLoginPage)ScenarioContext.Current["accountLoginPage"];
            Assert.IsTrue(accountLoginPage.loginButton.Displayed); 
        }
        
        [Then(@"I should see the Invalid Username and Password Error")]
        public void ThenIShouldSeeTheInvalidUsernameAndPasswordError()
        {
            MKAccountLoginPage accountLoginPage = (MKAccountLoginPage)ScenarioContext.Current["accountLoginPage"];
            IWebElement myAccountLoginPageError = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(accountLoginPage.errorMessage.GetAttribute("id"))));
            Assert.IsTrue(myAccountLoginPageError.Text.Contains("Incorrect"));
        }

        [Then(@"I should be on the My Account Page")]
        public void ThenIShouldBeOnTheMyAccountPage()
        {
            MKAccountLoginPage accountLoginPage = (MKAccountLoginPage)ScenarioContext.Current["accountLoginPage"];
            MKMyAccountPage myAccountPage = new MKMyAccountPage(driver);
            IWebElement myAccountFirstName = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(myAccountPage.accountFirstNameBanner.GetAttribute("id"))));
            Assert.IsTrue(myAccountFirstName.Displayed);
        }
    }
}
