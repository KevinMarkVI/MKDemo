using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject1.PageObjects.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1
{
    [Binding]
    public class MKIndividualTestsSteps
    {
        public IWebDriver driver = (IWebDriver)ScenarioContext.Current["driver"];

        [Given(@"I am on the Miles Kimball homepage")]
        public void GivenIAmOnTheMilesKimballHomepage()
        {
            driver.Navigate().GoToUrl(MKHomePage.URL);
            //Pause for popup transition
            System.Threading.Thread.Sleep(3000);
        }
        
        [Given(@"the Free Shipping alert Appears")]
        public void GivenTheFreeShippingAlertAppears()
        {
            MKHomePage homePage = new MKHomePage(driver);
            ScenarioContext.Current["homePage"] = homePage;
            Assert.IsTrue(homePage.closePopup.Displayed);
        }
        
        [When(@"I dismiss the popup")]
        public void WhenIDismissThePopup()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            homePage.closePopup.Click();
            //Pause for popup transition
            System.Threading.Thread.Sleep(3000);
        }

        [Then(@"the alert should not be present")]
        public void ThenTheAlertShouldNotBePresent()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            Assert.IsTrue(!homePage.closePopup.Displayed);
        }

        [Given(@"I dismiss the Free Shipping popup")]
        public void GivenIDismissThePopup()
        {
            MKHomePage homePage = new MKHomePage(driver);
            ScenarioContext.Current["homePage"] = homePage;
            homePage.closePopup.Click();
            //Pause for popup transition
            System.Threading.Thread.Sleep(3000);
        }

        [When(@"I enter the SKU in the search box and submit")]
        public void WhenIEnterTheSKUInTheSearchBoxAndSubmit()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            homePage.search("340665");
        }

        [Then(@"I should be on the Paua Shamrock product page")]
        public void ThenIShouldBeOnThePauaShamrockProductPage()
        {
            Assert.IsTrue(driver.Url.Contains("340665"));
        }

        [Given(@"I am on the product page")]
        public void GivenIAmOnTheProductPage()
        {
            driver.Navigate().GoToUrl(MKProductPage.URL);
            MKProductPage productPage = new MKProductPage(driver);
            ScenarioContext.Current["productPage"] = productPage;
        }

        [When(@"I click the Add to Cart Button")]
        public void WhenIClickTheAddToCartButton()
        {
            MKProductPage productPage = (MKProductPage)ScenarioContext.Current["productPage"];
            productPage.addToCartButton.Click();
            //Wait for popup to be displayed
            System.Threading.Thread.Sleep(1000);
        }

        [Then(@"the popup should appear with the correct information")]
        public void ThenThePopupShouldAppearWithTheCorrectInformation()
        {
            MKProductPage productPage = (MKProductPage)ScenarioContext.Current["productPage"];
            Assert.AreEqual(productPage.popupProductDescription.Text, "Paua Shamrock Earrings");
            Assert.AreEqual(productPage.popupProductPrice.Text, "$6.99");
            Assert.AreEqual(productPage.popupProductNumber.Text, "340665");
        }

        [When(@"I click the View Cart / Checkout Button")]
        public void WhenIClickTheViewCartCheckoutButton()
        {
            MKProductPage productPage = (MKProductPage)ScenarioContext.Current["productPage"];
            productPage.popupViewCartCheckoutButton.Click();
        }

        [Then(@"I should be on the shopping cart page")]
        public void ThenIShouldBeOnTheCartPageAndTheCorrectInformationShouldBeDisplayed()
        {
            Assert.IsTrue(driver.Url.Contains("shoppingcart"));

        }

        [Given(@"I am on the Shopping Cart Page")]
        public void GivenIAmOnTheShoppingCartPage()
        {
            driver.Navigate().GoToUrl(MKProductPage.URL);
            //Pause for popup transition
            System.Threading.Thread.Sleep(3000);
            MKProductPage productPage = new MKProductPage(driver);

            productPage.closePopup.Click();
            //Pause for popup transition
            System.Threading.Thread.Sleep(3000);

            productPage.addToCartButton.Click();
            //Wait for popup to be displayed
            System.Threading.Thread.Sleep(1000);

            productPage.popupViewCartCheckoutButton.Click();
            MKShoppingCartPage shoppingCartPage = new MKShoppingCartPage(driver);
            ScenarioContext.Current["shoppingCartPage"] = shoppingCartPage;
        }

        [Then(@"The expected information should be present")]
        public void ThenTheExpectedInformationShouldBePresent()
        {
            MKShoppingCartPage shoppingCartPage = (MKShoppingCartPage)ScenarioContext.Current["shoppingCartPage"];
            Assert.AreEqual(shoppingCartPage.merchandiseTotal.Text, "$6.99");
            Assert.AreEqual(shoppingCartPage.processing.Text, "$1.99");
            Assert.AreEqual(shoppingCartPage.subTotal.Text, "$12.97");
        }

        [When(@"I click on the Checkout button")]
        public void WhenIClickOnTheCheckoutButton()
        {
            MKShoppingCartPage shoppingCartPage = (MKShoppingCartPage)ScenarioContext.Current["shoppingCartPage"];
            shoppingCartPage.checkoutButton.Click();
        }

        [Then(@"I should see the Checkout as Guest Button")]
        public void ThenIShouldBeOnTheCheckoutStepPage()
        {
            MKLoginPage loginPage = new MKLoginPage(driver);
            Assert.IsTrue(loginPage.checkoutAsGuestButton.Displayed);
        }


        [When(@"I click on the Checkout as Guest Button")]
        public void WhenIClickOnTheCheckoutAsGuestButton()
        {
            MKLoginPage loginPage = new MKLoginPage(driver);
            loginPage.checkoutAsGuestButton.Click();
        }

        [Then(@"I should be on the first Checkout Page")]
        public void ThenIShouldBeOnTheFirstCheckoutPage()
        {
            MKCheckoutPage1 checkoutPage1 = new MKCheckoutPage1(driver);
            Assert.IsTrue(checkoutPage1.firstNameInput.Displayed);
        }

        [Given(@"I am on the first Checkout Page")]
        public void GivenIAmOnTheFirstCheckoutPage()
        {
            driver.Navigate().GoToUrl(MKProductPage.URL);
            //Pause for popup transition
            System.Threading.Thread.Sleep(3000);
            MKProductPage productPage = new MKProductPage(driver);

            productPage.closePopup.Click();
            //Pause for popup transition
            System.Threading.Thread.Sleep(3000);

            productPage.addToCartButton.Click();
            //Wait for popup to be displayed
            System.Threading.Thread.Sleep(1000);

            productPage.popupViewCartCheckoutButton.Click();
            MKShoppingCartPage shoppingCartPage = new MKShoppingCartPage(driver);
            shoppingCartPage.checkoutButton.Click();

            MKLoginPage loginPage = new MKLoginPage(driver);
            loginPage.checkoutAsGuestButton.Click();

            MKCheckoutPage1 checkoutPage1 = new MKCheckoutPage1(driver);
            ScenarioContext.Current["checkoutPage1"] = checkoutPage1;

        }

        [When(@"I complete the form")]
        public void WhenICompleteTheForm()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.completeForm();
        }

        [When(@"I click the Proceed to Payment and Review Button")]
        public void WhenIClickTheProceedToPaymentAndReviewButton()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.proceedToPaymentAndReviewButton.Click();
            //Wait for form submit
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"I should be on the second checkout page")]
        public void ThenIShouldBeOnTheSecondCheckoutPage()
        {
            MKCheckoutPage2 checkoutPage2 = new MKCheckoutPage2(driver);
            Assert.IsTrue(checkoutPage2.title.Contains("Step 2"));
        }

    }
}
