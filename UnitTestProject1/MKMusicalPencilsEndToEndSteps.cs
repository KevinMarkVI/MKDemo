using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject1.PageObjects.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [Binding]
    public class MKMusicalPencislEndtoEndSteps
    {
        public static IWebDriver driver = (IWebDriver)ScenarioContext.Current["driver"];
        public WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        [Given(@"I click on Kids")]
        public void GivenIClickOnKids()
        {
            MKHomePage homePage = (MKHomePage)ScenarioContext.Current["homePage"];
            IWebElement kidsNavLink = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(homePage.kidsNavButton.GetAttribute("id"))));
            kidsNavLink.Click();
            MKKidsPage kidsPage = new MKKidsPage(driver);
            ScenarioContext.Current["kidsPage"] = kidsPage;
        }

        [Given(@"I click on Pencils and Pencil Cases")]
        public void GivenIClickOnPencilsAndPencilCases()
        {
            MKKidsPage kidsPage = (MKKidsPage)ScenarioContext.Current["kidsPage"];
            kidsPage.closeFreeShippingPopup();
            //TODO: Hide logic in wait
            IWebElement pencilSubLink = wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("pencils")));
            pencilSubLink.Click();
            ScenarioContext.Current["kidsPage"] = kidsPage;
        }

        [Given(@"I choose All from the Items per page selector")]
        public void GivenIChooseAllFromTheItemsPerPageSelector()
        {
            MKKidsPage kidsPage = (MKKidsPage)ScenarioContext.Current["kidsPage"];
            IWebElement kidsPageItemsSelector = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(kidsPage.itemsPerPageSelector.GetAttribute("id"))));
            SelectElement itemsPerPageSelector = new SelectElement(kidsPageItemsSelector);
            itemsPerPageSelector.SelectByValue("999999");
            ScenarioContext.Current["kidsPage"] = kidsPage;
        }

        [Given(@"I click on the personalized musical notes pencils")]
        public void GivenIClickOnThePersonalizedMusicalNotesPencils()
        {
            MKKidsPage kidsPage = (MKKidsPage)ScenarioContext.Current["kidsPage"];
            kidsPage.musicalNotePencilsLink.Click();
            MKProductPage productPage = new MKProductPage(driver);
            IWebElement displayName = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(productPage.productDisplayName.GetAttribute("id"))));
            Assert.IsTrue(displayName.Displayed);
            ScenarioContext.Current["productPage"] = productPage;
        }

        [Given(@"I click personalize")]
        public void GivenIClickPersonalize()
        {
            MKProductPage productPage = (MKProductPage)ScenarioContext.Current["productPage"];
            productPage.personalizeButton.Click();
            IWebElement nameMessageInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(productPage.personalizeNameMessageInput.GetAttribute("id"))));
            Assert.IsTrue(nameMessageInput.Displayed);
            ScenarioContext.Current["productPage"] = productPage;
        }

        [Given(@"I enter Mr. Rodgers neighborhood in the input")]
        public void GivenIEnterMrRodgersNeighborhoodInTheInput()
        {
            MKProductPage productPage = (MKProductPage)ScenarioContext.Current["productPage"];
            productPage.personalizeNameMessageInput.SendKeys("Mr. Rodger's Neighborhood");
            ScenarioContext.Current["productPage"] = productPage;
        }

        [Given(@"I click the personalization approval")]
        public void GivenIClickThePersonalizationApproval()
        {
            MKProductPage productPage = (MKProductPage)ScenarioContext.Current["productPage"];
            productPage.approvePersonalizationCheckbox.Click();
            ScenarioContext.Current["productPage"] = productPage;
        }

        [Given(@"I then click add to cart")]
        public void GivenIThenClickAddToCart()
        {
            MKProductPage productPage = (MKProductPage)ScenarioContext.Current["productPage"];
            IWebElement afterPersonalizationAddToCartButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(productPage.personalizationAddToCartButton.GetAttribute("id"))));
            afterPersonalizationAddToCartButton.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement popupViewCartCheckoutButtonWait = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(productPage.popupViewCartCheckoutButton.GetAttribute("id"))));
            Assert.IsTrue(popupViewCartCheckoutButtonWait.Displayed);
            ScenarioContext.Current["productPage"] = productPage;
        }

        [Given(@"I then click View Cart / Checkout")]
        public void GivenIThenClickViewCartCheckout()
        {
            MKProductPage productPage = (MKProductPage)ScenarioContext.Current["productPage"];
            productPage.popupViewCartCheckoutButton.Click();
            MKShoppingCartPage shoppingCartPage = new MKShoppingCartPage(driver);
            IWebElement shoppingCartCheckoutButtonWait = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(shoppingCartPage.checkoutButton.GetAttribute("id"))));
            Assert.IsTrue(shoppingCartCheckoutButtonWait.Displayed);
            ScenarioContext.Current["shoppingCartPage"] = shoppingCartPage;
        }

        [Given(@"I enter the promotional code and apply")]
        public void GivenIEnterThePromotionalCodeAndApply()
        {
            MKShoppingCartPage shoppingCartPage = (MKShoppingCartPage)ScenarioContext.Current["shoppingCartPage"];
            shoppingCartPage.promoCodeInput.Clear();
            shoppingCartPage.promoCodeInput.SendKeys(MKShoppingCartPage.promoCode);
            shoppingCartPage.promoCodeApplyButton.Click();
            System.Threading.Thread.Sleep(2000);
            ScenarioContext.Current["shoppingCartPage"] = shoppingCartPage;
        }

        [Given(@"I choose premium shipping from the selector")]
        public void GivenIChoosePremiumShippingFromTheSelector()
        {
            MKShoppingCartPage shoppingCartPage = (MKShoppingCartPage)ScenarioContext.Current["shoppingCartPage"];
            shoppingCartPage.shippingSelector.Click();
            shoppingCartPage.premiumShippingSelector.Click();
            ScenarioContext.Current["shoppingCartPage"] = shoppingCartPage;

        }

        [Given(@"I then click the bottom checkout button")]
        public void GivenIThenClickTheBottomCheckoutButton()
        {
            MKShoppingCartPage shoppingCartPage = (MKShoppingCartPage)ScenarioContext.Current["shoppingCartPage"];
            shoppingCartPage.checkoutButton.Click();
            MKLoginPage loginPage = new MKLoginPage(driver);
            IWebElement checkoutAsGuestButtonWait = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(loginPage.checkoutAsGuestButton.GetAttribute("id"))));
            Assert.IsTrue(checkoutAsGuestButtonWait.Displayed);
            ScenarioContext.Current["loginPage"] = loginPage;
        }

        [Given(@"I click the Checkout as Guest button")]
        public void GivenIClickTheCheckoutAsGuestButton()
        {
            MKLoginPage loginPage = (MKLoginPage)ScenarioContext.Current["loginPage"];
            loginPage.checkoutAsGuestButton.Click();
            MKCheckoutPage1 checkoutPage1 = new MKCheckoutPage1(driver);
            IWebElement checkoutPage1Input = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(checkoutPage1.firstNameInput.GetAttribute("id"))));
            Assert.IsTrue(checkoutPage1Input.Displayed);
            ScenarioContext.Current["checkoutPage1"] = checkoutPage1;

        }

        [Given(@"I complete the form accordingly")]
        public void GivenICompleteTheFormAccordingly()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.taxCompleteForm();
            ScenarioContext.Current["checkoutPage1"] = checkoutPage1;

        }

        [Given(@"I uncheck the Special Offers and Emails box")]
        public void GivenIUncheckTheSpecialOffersAndEmailsBox()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.specialOffersCheckbox.Click();
            ScenarioContext.Current["checkoutPage1"] = checkoutPage1;
        }

        [Given(@"I check the button to ship to a different address")]
        public void GivenICheckTheButtonToShipToADifferentAddress()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.shipToDifferentAddressCheckbox.Click();
            ScenarioContext.Current["checkoutPage1"] = checkoutPage1;
        }

        [Given(@"I enter the additional address")]
        public void GivenIEnterTheAdditionalAddress()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.completeAdditionalAddress();
            ScenarioContext.Current["checkoutPage1"] = checkoutPage1;
        }

        [Given(@"I click the radio button to designate the item is a gift")]
        public void GivenIClickTheRadioButtonToDesignateTheItemIsAGift()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.giftYesRadioButton.Click();
            ScenarioContext.Current["checkoutPage1"] = checkoutPage1;
        }

        [Given(@"I click the button to Proceed to Payment and Review")]
        public void GivenIClickTheButtonToProceedToPaymentAndReview()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.proceedToPaymentAndReviewButton.Click();
            MKCheckoutPage2 checkoutPage2 = new MKCheckoutPage2(driver);
            IWebElement checkoutPage2Input = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(checkoutPage2.paymentTypeSelector.GetAttribute("id"))));
            Assert.IsTrue(checkoutPage2Input.Displayed);
            ScenarioContext.Current["checkoutPage2"] = checkoutPage2;
        }

        [Given(@"I fill out the payment information")]
        public void GivenIFillOutThePaymentInformation()
        {
            MKCheckoutPage2 checkoutPage2 = (MKCheckoutPage2)ScenarioContext.Current["checkoutPage2"];
            checkoutPage2.completePaymentInfo();
            ScenarioContext.Current["checkoutPage2"] = checkoutPage2;
        }

        [Given(@"I click the button to submit the order")]
        public void GivenIClickTheButtonToSubmitTheOrder()
        {
            MKCheckoutPage2 checkoutPage2 = (MKCheckoutPage2)ScenarioContext.Current["checkoutPage2"];
            checkoutPage2.submitOrderButton.Click();
            MKOrderConfirmationPage orderConfirmationPage = new MKOrderConfirmationPage(driver);
            IWebElement confirmationPagePopupElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(orderConfirmationPage.googlePopupWindow.GetAttribute("id"))));
            Assert.IsTrue(confirmationPagePopupElement.Displayed);
            ScenarioContext.Current["orderConfirmationPage"] = orderConfirmationPage;
        }

        [Given(@"I close all of the popup windows")]
        public void GivenICloseAllOfThePopupWindows()
        {
            MKOrderConfirmationPage orderConfirmationPage = (MKOrderConfirmationPage)ScenarioContext.Current["orderConfirmationPage"];
            orderConfirmationPage.closePopupWindows();
            ScenarioContext.Current["orderConfirmationPage"] = orderConfirmationPage;
        }

        [Then(@"I will be on the Order Confirmation Page")]
        public void ThenIWillBeOnTheOrderConfirmationPage()
        {
            MKOrderConfirmationPage orderConfirmationPage = (MKOrderConfirmationPage)ScenarioContext.Current["orderConfirmationPage"];
            Assert.AreEqual(orderConfirmationPage.confirmationOrderTotal.Text, "$22.04");
        }
    }
}
