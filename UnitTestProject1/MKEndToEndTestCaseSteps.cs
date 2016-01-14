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
    public class MKEndToEndTestCaseSteps
    {

        public IWebDriver driver = (IWebDriver)ScenarioContext.Current["driver"];

        [Given(@"I am on the Miles Kimball website")]
        public void GivenIAmOnTheMilesKimballWebsite()
        {
            driver.Navigate().GoToUrl(MKHomePage.URL);
            MKHomePage homePage = new MKHomePage(driver);
            //Pause for popup transition
            System.Threading.Thread.Sleep(3000);
            ScenarioContext.Current["homePage"] = homePage;
        }
        
        [Given(@"I dismiss the popup")]
        public void GivenIDismissThePopup()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            homePage.closePopup.Click();
            //Pause for popup transition
            System.Threading.Thread.Sleep(3000);
        }
        
        [Given(@"I search for Paua Shamrock Earrings using the SKU")]
        public void GivenISearchForPauaShamrockEarringsUsingTheSKU()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            homePage.search("340665");
        }
        
        [Given(@"I click add to cart")]
        public void GivenIClickAddToCart()
        {
            MKProductPage productPage = new MKProductPage(driver);
            productPage.addToCartButton.Click();
            //Wait for popup to be displayed
            System.Threading.Thread.Sleep(1000);
            ScenarioContext.Current["productPage"] = productPage;
        }
        
        [Given(@"I click View Cart / Checkout")]
        public void GivenIClickViewCartCheckout()
        {
            MKProductPage productPage = (MKProductPage)ScenarioContext.Current["productPage"];
            productPage.popupViewCartCheckoutButton.Click();
        }
        
        [Given(@"I click Checkout")]
        public void GivenIClickCheckout()
        {
            MKShoppingCartPage shoppingCartPage = new MKShoppingCartPage(driver);
            shoppingCartPage.checkoutButton.Click();
        }
        
        [Given(@"I click Checkout as Guest")]
        public void GivenIClickCheckoutAsGuest()
        {
            MKLoginPage loginPage = new MKLoginPage(driver);
            loginPage.checkoutAsGuestButton.Click();
        }
        
        [Given(@"Complete the various fields")]
        public void GivenCompleteTheVariousFields()
        {
            MKCheckoutPage1 checkoutPage1 = new MKCheckoutPage1(driver);
            checkoutPage1.completeForm();
            ScenarioContext.Current["checkoutPage1"] = checkoutPage1;
        }
        
        [Given(@"I click Proceed to Payment & Review")]
        public void GivenIClickProceedToPaymentReview()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.proceedToPaymentAndReviewButton.Click();
            //Pause for form submit
            System.Threading.Thread.Sleep(2000);
        }
        
        [Given(@"I enter payment information")]
        public void GivenIEnterPaymentInformation()
        {
            MKCheckoutPage2 checkoutPage2 = new MKCheckoutPage2(driver);
            checkoutPage2.completePaymentInfo();
            ScenarioContext.Current["checkoutPage2"] = checkoutPage2;

        }
        
        [Given(@"I click Submit Order")]
        public void GivenIClickSubmitOrder()
        {
            MKCheckoutPage2 checkoutPage2 = (MKCheckoutPage2)ScenarioContext.Current["checkoutPage2"];
            checkoutPage2.submitOrderButton.Click();
            //Popup Transition
            System.Threading.Thread.Sleep(3000);
        }
        
        [Given(@"I dismiss the popup windows")]
        public void GivenIDismissThePopupWindows()
        {
            MKOrderConfirmationPage orderConfirmationPage = new MKOrderConfirmationPage(driver);
            orderConfirmationPage.closePopupWindows();
            ScenarioContext.Current["orderConfirmationPage"] = orderConfirmationPage;
        }
        
        [Then(@"the receipt page should confirm the order")]
        public void ThenTheReceiptPageShouldConfirmTheOrder()
        {
            MKOrderConfirmationPage orderConfirmationPage = (MKOrderConfirmationPage)ScenarioContext.Current["orderConfirmationPage"];
            Assert.AreEqual(orderConfirmationPage.confirmationOrderTotal.Text, "$12.97");
        }
    }
}
