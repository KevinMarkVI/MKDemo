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

        public static IWebDriver driver = (IWebDriver)ScenarioContext.Current["driver"];
        public WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        [Given(@"I am on the Miles Kimball website")]
        public void GivenIAmOnTheMilesKimballWebsite()
        {
            driver.Navigate().GoToUrl(MKHomePage.URL);
            MKHomePage homePage = new MKHomePage(driver);
            ScenarioContext.Current["homePage"] = homePage;
        }
        
        [Given(@"I dismiss the popup")]
        public void GivenIDismissThePopup()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            homePage.closePopup.Click();
            ScenarioContext.Current["homePage"] = homePage;
        }
        
        [Given(@"I search for Paua Shamrock Earrings using the SKU")]
        public void GivenISearchForPauaShamrockEarringsUsingTheSKU()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            IWebElement searchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(homePage.searchInput.GetAttribute("id"))));
            Assert.IsTrue(searchInput.Displayed);
            homePage.search("340665");
            MKProductPage productPage = new MKProductPage(driver);
            IWebElement addToCartButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(productPage.addToCartButton.GetAttribute("id"))));
            Assert.IsTrue(addToCartButton.Displayed);
            ScenarioContext.Current["productPage"] = productPage;
        }
        
        [Given(@"I click add to cart")]
        public void GivenIClickAddToCart()
        {
            MKProductPage productPage = (MKProductPage)ScenarioContext.Current["productPage"];
            productPage.addToCartButton.Click();
            System.Threading.Thread.Sleep(2000);
            ScenarioContext.Current["productPage"] = productPage;
        }
        
        [Given(@"I click View Cart / Checkout")]
        public void GivenIClickViewCartCheckout()
        {
            MKProductPage productPage = (MKProductPage)ScenarioContext.Current["productPage"];
            IWebElement popupViewCartProductButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(productPage.popupViewCartCheckoutButton.GetAttribute("id"))));
            popupViewCartProductButton.Click();
            MKShoppingCartPage shoppingCartPage = new MKShoppingCartPage(driver);
            IWebElement shoppingCartCheckoutButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(shoppingCartPage.checkoutButton.GetAttribute("id"))));
            Assert.IsTrue(shoppingCartCheckoutButton.Displayed);
            ScenarioContext.Current["shoppingCartPage"] = shoppingCartPage;
        }
        
        [Given(@"I click Checkout")]
        public void GivenIClickCheckout()
        {
            MKShoppingCartPage shoppingCartPage = (MKShoppingCartPage)ScenarioContext.Current["shoppingCartPage"];
            shoppingCartPage.checkoutButton.Click();
            MKLoginPage loginPage = new MKLoginPage(driver);
            IWebElement loginPageElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(loginPage.checkoutAsGuestButton.GetAttribute("id"))));
            Assert.IsTrue(loginPageElement.Displayed);
            ScenarioContext.Current["loginPage"] = loginPage;
        }
        
        [Given(@"I click Checkout as Guest")]
        public void GivenIClickCheckoutAsGuest()
        {
            MKLoginPage loginPage = (MKLoginPage)ScenarioContext.Current["loginPage"];
            loginPage.checkoutAsGuestButton.Click();
            MKCheckoutPage1 checkoutPage1 = new MKCheckoutPage1(driver);
            IWebElement checkoutPage1Input = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(checkoutPage1.lastNameInput.GetAttribute("id"))));
            Assert.IsTrue(checkoutPage1Input.Displayed);
            ScenarioContext.Current["checkoutPage1"] = checkoutPage1;
        }
        
        [Given(@"Complete the various fields")]
        public void GivenCompleteTheVariousFields()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.completeForm();
            ScenarioContext.Current["checkoutPage1"] = checkoutPage1;
        }
        
        [Given(@"I click Proceed to Payment & Review")]
        public void GivenIClickProceedToPaymentReview()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.proceedToPaymentAndReviewButton.Click();
            MKCheckoutPage2 checkoutPage2 = new MKCheckoutPage2(driver);
            IWebElement checkoutPage2Button = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(checkoutPage2.submitOrderButton.GetAttribute("id"))));
            Assert.IsTrue(checkoutPage2Button.Displayed);
            ScenarioContext.Current["checkoutPage2"] = checkoutPage2;
        }
        
        [Given(@"I enter payment information")]
        public void GivenIEnterPaymentInformation()
        {
            MKCheckoutPage2 checkoutPage2 = (MKCheckoutPage2)ScenarioContext.Current["checkoutPage2"];
            checkoutPage2.completePaymentInfo();
            ScenarioContext.Current["checkoutPage2"] = checkoutPage2;

        }
        
        [Given(@"I click Submit Order")]
        public void GivenIClickSubmitOrder()
        {
            MKCheckoutPage2 checkoutPage2 = (MKCheckoutPage2)ScenarioContext.Current["checkoutPage2"];
            checkoutPage2.submitOrderButton.Click();
            MKOrderConfirmationPage orderConfirmationPage = new MKOrderConfirmationPage(driver);
            IWebElement confirmationPagePopupElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(orderConfirmationPage.googlePopupWindow.GetAttribute("id"))));
            Assert.IsTrue(confirmationPagePopupElement.Displayed);
            ScenarioContext.Current["orderConfirmationPage"] = orderConfirmationPage;
        }
        
        [Given(@"I dismiss the popup windows")]
        public void GivenIDismissThePopupWindows()
        {
            MKOrderConfirmationPage orderConfirmationPage = (MKOrderConfirmationPage)ScenarioContext.Current["orderConfirmationPage"];
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
