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
    public class MKIndividualTestsSteps
    {
        public static IWebDriver driver = (IWebDriver)ScenarioContext.Current["driver"];
        public WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        [Given(@"I am on the Miles Kimball homepage")]
        public void GivenIAmOnTheMilesKimballHomepage()
        {
            driver.Navigate().GoToUrl(MKHomePage.URL);
            MKHomePage homePage = new MKHomePage(driver);
            ScenarioContext.Current["homePage"] = homePage;
        }


        [Then(@"the free shipping alert should be present")]
        public void ThenTheAlertShouldBePresent()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            IWebElement popUp = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(homePage.closePopup.GetAttribute("id"))));
            Assert.IsTrue(popUp.Displayed);
        }

        [Given(@"the Free Shipping alert Appears")]
        public void GivenTheFreeShippingAlertAppears()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            IWebElement popUp = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(homePage.closePopup.GetAttribute("id"))));
            Assert.IsTrue(popUp.Displayed);
            ScenarioContext.Current["homePage"] = homePage;
        }

        [When(@"I dismiss the popup")]
        public void WhenIDismissThePopup()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            homePage.closePopup.Click();
        }

        [Then(@"the alert should not be present")]
        public void ThenTheAlertShouldNotBePresent()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            IWebElement searchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(homePage.searchInput.GetAttribute("id"))));
            Assert.IsTrue(searchInput.Displayed);
        }

        [Given(@"I dismiss the Free Shipping popup")]
        public void GivenIDismissThePopup()
        {
            MKHomePage homePage = new MKHomePage(driver);
            IWebElement popUp = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(homePage.closePopup.GetAttribute("id"))));
            popUp.Click();
            ScenarioContext.Current["homePage"] = homePage;
        }

        [When(@"I enter the SKU in the search box and submit")]
        public void WhenIEnterTheSKUInTheSearchBoxAndSubmit()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            IWebElement searchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(homePage.searchInput.GetAttribute("id"))));
            Assert.IsTrue(searchInput.Displayed);
            homePage.search("340665");
        }

        [Then(@"I should be on the Paua Shamrock product page")]
        public void ThenIShouldBeOnThePauaShamrockProductPage()
        {
            MKProductPage productPage = new MKProductPage(driver);
            IWebElement addToCartButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(productPage.addToCartButton.GetAttribute("id"))));
            Assert.IsTrue(addToCartButton.Displayed);
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
            IWebElement productPageAddToCart = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(productPage.addToCartButton.GetAttribute("id"))));
            productPageAddToCart.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement productPopUp = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(productPage.popupViewCartCheckoutButton.GetAttribute("id"))));
            Assert.IsTrue(productPopUp.Displayed);
            ScenarioContext.Current["productPage"] = productPage;
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
            IWebElement productPopUpViewCartButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(productPage.popupViewCartCheckoutButton.GetAttribute("id"))));
            productPopUpViewCartButton.Click();
            MKShoppingCartPage shoppingCartPage = new MKShoppingCartPage(driver);
            IWebElement shoppingCartCheckoutButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(shoppingCartPage.checkoutButton.GetAttribute("id"))));
            Assert.IsTrue(shoppingCartCheckoutButton.Displayed);
            ScenarioContext.Current["shoppingCartPage"] = shoppingCartPage;
        }

        [Then(@"I should be on the shopping cart page")]
        public void ThenIShouldBeOnTheCartPageAndTheCorrectInformationShouldBeDisplayed()
        {
            MKShoppingCartPage shoppingCartPage = (MKShoppingCartPage)ScenarioContext.Current["shoppingCartPage"];
            Assert.IsTrue(shoppingCartPage.checkoutButton.Displayed);
        }

        [Given(@"I am on the Shopping Cart Page")]
        public void GivenIAmOnTheShoppingCartPage()
        {
            driver.Navigate().GoToUrl(MKProductPage.URL);
            MKProductPage productPage = new MKProductPage(driver);
            productPage.closePopup.Click();
            IWebElement productPageAddToCart = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(productPage.addToCartButton.GetAttribute("id"))));
            productPageAddToCart.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement popupViewCartProductButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(productPage.popupViewCartCheckoutButton.GetAttribute("id"))));
            popupViewCartProductButton.Click();
            MKShoppingCartPage shoppingCartPage = new MKShoppingCartPage(driver);
            IWebElement shoppingCartCheckoutButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(shoppingCartPage.checkoutButton.GetAttribute("id"))));
            Assert.IsTrue(shoppingCartCheckoutButton.Displayed);
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
            MKLoginPage loginPage = new MKLoginPage(driver);
            IWebElement loginPageCheckoutButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(loginPage.checkoutAsGuestButton.GetAttribute("id"))));
            Assert.IsTrue(loginPageCheckoutButton.Displayed);
            ScenarioContext.Current["loginPage"] = loginPage;
        }

        [Then(@"I should see the Checkout as Guest Button")]
        public void ThenIShouldBeOnTheCheckoutStepPage()
        {
            MKLoginPage loginPage = (MKLoginPage)ScenarioContext.Current["loginPage"];
            Assert.IsTrue(loginPage.checkoutAsGuestButton.Displayed);
        }

        [When(@"I click on the Checkout as Guest Button")]
        public void WhenIClickOnTheCheckoutAsGuestButton()
        {
            MKLoginPage loginPage = (MKLoginPage)ScenarioContext.Current["loginPage"];
            loginPage.checkoutAsGuestButton.Click();
            MKCheckoutPage1 checkoutPage1 = new MKCheckoutPage1(driver);
            IWebElement checkoutPage1Input = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(checkoutPage1.lastNameInput.GetAttribute("id"))));
            Assert.IsTrue(checkoutPage1Input.Displayed);
            ScenarioContext.Current["checkoutPage1"] = checkoutPage1;
        }

        [Then(@"I should be on the first Checkout Page")]
        public void ThenIShouldBeOnTheFirstCheckoutPage()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            Assert.IsTrue(checkoutPage1.firstNameInput.Displayed);
        }

        [Given(@"I am on the first Checkout Page")]
        public void GivenIAmOnTheFirstCheckoutPage()
        {
            driver.Navigate().GoToUrl(MKProductPage.URL);
            MKProductPage productPage = new MKProductPage(driver);
            productPage.closePopup.Click();
            IWebElement productPageAddToCart = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(productPage.addToCartButton.GetAttribute("id"))));
            productPageAddToCart.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement popupViewCartProductButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(productPage.popupViewCartCheckoutButton.GetAttribute("id"))));
            popupViewCartProductButton.Click();
            MKShoppingCartPage shoppingCartPage = new MKShoppingCartPage(driver);
            IWebElement shoppingCartCheckoutButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(shoppingCartPage.checkoutButton.GetAttribute("id"))));
            shoppingCartCheckoutButton.Click();
            MKLoginPage loginPage = new MKLoginPage(driver);
            IWebElement loginPageCheckoutButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(loginPage.checkoutAsGuestButton.GetAttribute("id"))));
            loginPageCheckoutButton.Click();
            MKCheckoutPage1 checkoutPage1 = new MKCheckoutPage1(driver);
            IWebElement checkoutPage1Input = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(checkoutPage1.lastNameInput.GetAttribute("id"))));
            Assert.IsTrue(checkoutPage1Input.Displayed);
            ScenarioContext.Current["checkoutPage1"] = checkoutPage1;
        }

        [Then(@"I will confirm the summary information")]
        public void ThenIWillConfirmSummaryInformation()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            Assert.AreEqual(checkoutPage1.orderSummaryItems.Text, "1");
            Assert.AreEqual(checkoutPage1.orderSummaryMerchandiseTotal.Text, "$6.99");
            Assert.AreEqual(checkoutPage1.orderSummaryProcessingFee.Text, "$1.99");
            Assert.AreEqual(checkoutPage1.orderSummaryShippingAndHandling.Text, "$3.99");
            Assert.AreEqual(checkoutPage1.orderSummaryTotal.Text, "$12.97");
        }

        [When(@"I complete the form and confirm order summary information")]
        public void WhenICompleteTheForm()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.completeForm();
            Assert.AreEqual(checkoutPage1.shipToBillingAddressRadioButton.GetAttribute("checked"), "true");
            Assert.AreEqual(checkoutPage1.giftRadioButton.GetAttribute("checked"), "true");
            ScenarioContext.Current["checkoutPage1"] = checkoutPage1;
        }

        [When(@"I click the Proceed to Payment and Review Button")]
        public void WhenIClickTheProceedToPaymentAndReviewButton()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.proceedToPaymentAndReviewButton.Click();
            MKCheckoutPage2 checkoutPage2 = new MKCheckoutPage2(driver);
            IWebElement checkoutPage2Input = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(checkoutPage2.paymentTypeSelector.GetAttribute("id"))));
            Assert.IsTrue(checkoutPage2Input.Displayed);
            ScenarioContext.Current["checkoutPage2"] = checkoutPage2;
        }

        [Then(@"I should be on the second checkout page")]
        public void ThenIShouldBeOnTheSecondCheckoutPage()
        {
            MKCheckoutPage2 checkoutPage2 = (MKCheckoutPage2)ScenarioContext.Current["checkoutPage2"];
            Assert.IsTrue(checkoutPage2.submitOrderButton.Displayed);
        }

        [Given(@"I am on the second checkout page")]
        public void GivenIAmOnTheSecondCheckoutPage()
        {
            driver.Navigate().GoToUrl(MKProductPage.URL);
            MKProductPage productPage = new MKProductPage(driver);
            productPage.closePopup.Click();
            IWebElement productPageAddToCart = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(productPage.addToCartButton.GetAttribute("id"))));
            productPageAddToCart.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement popupViewCartProductButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(productPage.popupViewCartCheckoutButton.GetAttribute("id"))));
            popupViewCartProductButton.Click();
            MKShoppingCartPage shoppingCartPage = new MKShoppingCartPage(driver);
            IWebElement shoppingCartCheckoutButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(shoppingCartPage.checkoutButton.GetAttribute("id"))));
            shoppingCartCheckoutButton.Click();
            MKLoginPage loginPage = new MKLoginPage(driver);
            IWebElement loginPageCheckoutButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(loginPage.checkoutAsGuestButton.GetAttribute("id"))));
            loginPageCheckoutButton.Click();
            MKCheckoutPage1 checkoutPage1 = new MKCheckoutPage1(driver);
            IWebElement checkoutPage1Input = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(checkoutPage1.lastNameInput.GetAttribute("id"))));
            Assert.IsTrue(checkoutPage1Input.Displayed);
            checkoutPage1.completeForm();
            checkoutPage1.proceedToPaymentAndReviewButton.Click();
            MKCheckoutPage2 checkoutPage2 = new MKCheckoutPage2(driver);
            IWebElement checkoutPage2Button = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(checkoutPage2.submitOrderButton.GetAttribute("id"))));
            Assert.IsTrue(checkoutPage2Button.Displayed);
            ScenarioContext.Current["checkoutPage2"] = checkoutPage2;
        }

        [Then(@"the correct information should be present")]
        public void ThenTheCorrectInformationShouldBePresent()
        {
            MKCheckoutPage2 checkoutPage2 = (MKCheckoutPage2)ScenarioContext.Current["checkoutPage2"];
            Assert.AreEqual(checkoutPage2.summaryMerchandiseTotal.Text, "$6.99");
            Assert.AreEqual(checkoutPage2.summaryProcessingFee.Text, "$1.99");
            Assert.AreEqual(checkoutPage2.summaryShippingTotal.Text, "$3.99");
            Assert.AreEqual(checkoutPage2.summaryTaxTotal.Text, "$0.00");
            Assert.AreEqual(checkoutPage2.summaryTotal.Text, "$12.97");
            Assert.IsTrue(checkoutPage2.summaryShippedTo.Text.Contains("Test Automation"));
            Assert.AreEqual(checkoutPage2.summaryProductDescription.Text, "Paua Shamrock Earrings");
        }

        [When(@"I fill complete the payment information")]
        public void WhenIFillCompleteThePaymentInformation()
        {
            MKCheckoutPage2 checkoutPage2 = (MKCheckoutPage2)ScenarioContext.Current["checkoutPage2"];
            checkoutPage2.completePaymentInfo();
            ScenarioContext.Current["checkoutPage2"] = checkoutPage2;
        }

        [When(@"I click the submit order button")]
        public void WhenIClickTheSubmitOrderButton()
        {
            MKCheckoutPage2 checkoutPage2 = (MKCheckoutPage2)ScenarioContext.Current["checkoutPage2"];
            checkoutPage2.submitOrderButton.Click();
            MKOrderConfirmationPage orderConfirmationPage = new MKOrderConfirmationPage(driver);
            IWebElement confirmationPagePopupElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(orderConfirmationPage.googlePopupWindow.GetAttribute("id"))));
            Assert.IsTrue(confirmationPagePopupElement.Displayed);
            ScenarioContext.Current["orderConfirmationPage"] = orderConfirmationPage;
        }

        [Then(@"I should be on the receipt page")]
        public void ThenIShouldSeeTheGooglePopup()
        {
            MKOrderConfirmationPage orderConfirmationPage = (MKOrderConfirmationPage)ScenarioContext.Current["orderConfirmationPage"];
            Assert.IsTrue(orderConfirmationPage.googlePopupWindow.Displayed);
        }

        [Given(@"I am on the receipt page")]
        public void GivenIAmOnTheReceiptPage()
        {
            driver.Navigate().GoToUrl(MKProductPage.URL);
            MKProductPage productPage = new MKProductPage(driver);
            productPage.closePopup.Click();
            IWebElement productPageAddToCart = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(productPage.addToCartButton.GetAttribute("id"))));
            productPageAddToCart.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement popupViewCartProductButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(productPage.popupViewCartCheckoutButton.GetAttribute("id"))));
            popupViewCartProductButton.Click();
            MKShoppingCartPage shoppingCartPage = new MKShoppingCartPage(driver);
            IWebElement shoppingCartCheckoutButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(shoppingCartPage.checkoutButton.GetAttribute("id"))));
            shoppingCartCheckoutButton.Click();
            MKLoginPage loginPage = new MKLoginPage(driver);
            IWebElement loginPageCheckoutButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(loginPage.checkoutAsGuestButton.GetAttribute("id"))));
            loginPageCheckoutButton.Click();
            MKCheckoutPage1 checkoutPage1 = new MKCheckoutPage1(driver);
            IWebElement checkoutPage1Input = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(checkoutPage1.lastNameInput.GetAttribute("id"))));
            Assert.IsTrue(checkoutPage1Input.Displayed);
            checkoutPage1.completeForm();
            checkoutPage1.proceedToPaymentAndReviewButton.Click();
            MKCheckoutPage2 checkoutPage2 = new MKCheckoutPage2(driver);
            IWebElement checkoutPage2Button = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(checkoutPage2.submitOrderButton.GetAttribute("id"))));
            Assert.IsTrue(checkoutPage2Button.Displayed);
            checkoutPage2.completePaymentInfo();
            checkoutPage2.submitOrderButton.Click();
            MKOrderConfirmationPage orderConfirmationPage = new MKOrderConfirmationPage(driver);
            IWebElement confirmationPagePopupElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(orderConfirmationPage.googlePopupWindow.GetAttribute("id"))));
            Assert.IsTrue(confirmationPagePopupElement.Displayed);
            ScenarioContext.Current["orderConfirmationPage"] = orderConfirmationPage;
        }

        [When(@"I close the popups")]
        public void WhenICloseThePopups()
        {
            MKOrderConfirmationPage orderConfirmationPage = (MKOrderConfirmationPage)ScenarioContext.Current["orderConfirmationPage"];
            orderConfirmationPage.closePopupWindows();
            ScenarioContext.Current["orderConfirmationPage"] = orderConfirmationPage;
        }

        [Then(@"they should not be present")]
        public void ThenTheyShouldNotBePresent()
        {
            MKOrderConfirmationPage orderConfirmationPage = (MKOrderConfirmationPage)ScenarioContext.Current["orderConfirmationPage"];
            Assert.IsTrue(!orderConfirmationPage.googlePopupWindow.Displayed);
            Assert.IsTrue(!orderConfirmationPage.surveyPopupWindow.Displayed);
            Assert.IsTrue(!orderConfirmationPage.freeShippingPopupWindow.Displayed);
        }

        [Then(@"I will confirm all the pertinent information")]
        public void ThenConfirmAllPertinentInformation()
        {
            MKOrderConfirmationPage orderConfirmationPage = (MKOrderConfirmationPage)ScenarioContext.Current["orderConfirmationPage"];
            Assert.IsTrue(orderConfirmationPage.confirmationBillingAddress.Text.Contains("Test Automation"));
            Assert.AreEqual(orderConfirmationPage.confirmationPaymentMethod.Text, "Visa");
            Assert.AreEqual(orderConfirmationPage.confirmationShipMethod.Text, "4-8 Business Days*");
            Assert.AreEqual(orderConfirmationPage.confirmationMerchandiseTotal.Text, "$6.99");
            Assert.AreEqual(orderConfirmationPage.confirmationProcessingFee.Text, "$1.99");
            Assert.AreEqual(orderConfirmationPage.confirmationShippingTotal.Text, "$3.99");
            Assert.AreEqual(orderConfirmationPage.confirmationTaxTotal.Text, "$0.00");
            Assert.AreEqual(orderConfirmationPage.confirmationOrderTotal.Text, "$12.97");
        }
    }
}
