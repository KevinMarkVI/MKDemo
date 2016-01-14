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
        //START HERE
        [When(@"I click on the Checkout button")]
        public void WhenIClickOnTheCheckoutButton()
        {
            MKShoppingCartPage shoppingCartPage = (MKShoppingCartPage)ScenarioContext.Current["shoppingCartPage"];
            IWebElement shoppingCartCheckoutButton = wait.Until<IWebElement>((d) =>
            {
                return shoppingCartPage.checkoutButton;
            });
            shoppingCartCheckoutButton.Click();
        }

        [Then(@"I should see the Checkout as Guest Button")]
        public void ThenIShouldBeOnTheCheckoutStepPage()
        {
            MKLoginPage loginPage = new MKLoginPage(driver);
            IWebElement loginPageCheckoutButton = wait.Until<IWebElement>((d) =>
            {
                return loginPage.checkoutAsGuestButton;
            });
            Assert.IsTrue(loginPageCheckoutButton.Displayed);
        }

        [When(@"I click on the Checkout as Guest Button")]
        public void WhenIClickOnTheCheckoutAsGuestButton()
        {
            MKLoginPage loginPage = new MKLoginPage(driver);
            IWebElement loginPageCheckoutButton = wait.Until<IWebElement>((d) =>
            {
                return loginPage.checkoutAsGuestButton;
            });
            loginPageCheckoutButton.Click();
        }

        [Then(@"I should be on the first Checkout Page")]
        public void ThenIShouldBeOnTheFirstCheckoutPage()
        {
            MKCheckoutPage1 checkoutPage1 = new MKCheckoutPage1(driver);
            IWebElement checkoutPage1FirstNameInput = wait.Until<IWebElement>((d) =>
            {
                return checkoutPage1.firstNameInput;
            });
            Assert.IsTrue(checkoutPage1FirstNameInput.Displayed);
        }

        [Given(@"I am on the first Checkout Page")]
        public void GivenIAmOnTheFirstCheckoutPage()
        {
            driver.Navigate().GoToUrl(MKProductPage.URL);
            MKProductPage productPage = new MKProductPage(driver);

            productPage.closePopup.Click();

            IWebElement productAddToCartButton = wait.Until<IWebElement>((d) =>
            { 
                return productPage.addToCartButton;
            });
            productAddToCartButton.Click();

            IWebElement productPopupViewCartButton = wait.Until<IWebElement>((d) =>
            {
                MKProductPage productPageWait = new MKProductPage(d);
                return productPageWait.popupViewCartCheckoutButton;
            });
            productPopupViewCartButton.Click();

            IWebElement shoppingCartCheckoutButton = wait.Until<IWebElement>((d) =>
            {
                MKShoppingCartPage shoppingCartPageWait = new MKShoppingCartPage(d);
                return shoppingCartPageWait.checkoutButton;
            });
            shoppingCartCheckoutButton.Click();

            
            IWebElement loginPageCheckoutButton = wait.Until<IWebElement>((d) =>
            {
                MKLoginPage loginPage = new MKLoginPage(d);
                return loginPage.checkoutAsGuestButton;
            });
            loginPageCheckoutButton.Click();
            

            IWebElement shoppingCartProceedToPaymentButton = wait.Until<IWebElement>((d) =>
            {
                MKCheckoutPage1 checkoutPage1Wait = new MKCheckoutPage1(d);
                return checkoutPage1Wait.proceedToPaymentAndReviewButton;
            });
            Assert.IsTrue(shoppingCartProceedToPaymentButton.Displayed);
            MKCheckoutPage1 checkoutPage1 = new MKCheckoutPage1(driver);
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
        }

        [When(@"I click the Proceed to Payment and Review Button")]
        public void WhenIClickTheProceedToPaymentAndReviewButton()
        {
            MKCheckoutPage1 checkoutPage1 = (MKCheckoutPage1)ScenarioContext.Current["checkoutPage1"];
            checkoutPage1.proceedToPaymentAndReviewButton.Click();
        }

        [Then(@"I should be on the second checkout page")]
        public void ThenIShouldBeOnTheSecondCheckoutPage()
        {
            MKCheckoutPage2 checkoutPage2 = new MKCheckoutPage2(driver);
            IWebElement checkoutPage2SubmitButton = wait.Until<IWebElement>((d) =>
            {
                return checkoutPage2.submitOrderButton;
            });
            Assert.IsTrue(checkoutPage2SubmitButton.Displayed);
        }

        [Given(@"I am on the second checkout page")]
        public void GivenIAmOnTheSecondCheckoutPage()
        {
            driver.Navigate().GoToUrl(MKProductPage.URL);
            MKProductPage productPage = new MKProductPage(driver);
            IWebElement popUp = wait.Until<IWebElement>((d) =>
            {
                return productPage.closePopup;
            });
            popUp.Click();

            IWebElement productAddToCartButton = wait.Until<IWebElement>((d) =>
            {
                return productPage.addToCartButton;
            });
            productAddToCartButton.Click();

            IWebElement productPopupViewCartButton = wait.Until<IWebElement>((d) =>
            {
                return productPage.popupViewCartCheckoutButton;
            });
            productPopupViewCartButton.Click();

            MKShoppingCartPage shoppingCartPage = new MKShoppingCartPage(driver);

            IWebElement shoppingCartCheckoutButton = wait.Until<IWebElement>((d) =>
            {
                return shoppingCartPage.checkoutButton;
            });
            shoppingCartCheckoutButton.Click();

            MKLoginPage loginPage = new MKLoginPage(driver);
            IWebElement loginPageCheckoutButton = wait.Until<IWebElement>((d) =>
            {
                return loginPage.checkoutAsGuestButton;
            });
            loginPageCheckoutButton.Click();
            MKCheckoutPage1 checkoutPage1 = new MKCheckoutPage1(driver);

            IWebElement shoppingCartProceedToPaymentButton = wait.Until<IWebElement>((d) =>
            {
                return checkoutPage1.proceedToPaymentAndReviewButton;
            });

            MKCheckoutPage2 checkoutPage2 = new MKCheckoutPage2(driver);
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
        }

        [When(@"I click the submit order button")]
        public void WhenIClickTheSubmitOrderButton()
        {
            MKCheckoutPage2 checkoutPage2 = (MKCheckoutPage2)ScenarioContext.Current["checkoutPage2"];
            checkoutPage2.submitOrderButton.Click();
            //Wait for form submit
            System.Threading.Thread.Sleep(3000);
        }

        [Then(@"I should be on the receipt page")]
        public void ThenIShouldSeeTheGooglePopup()
        {
            MKOrderConfirmationPage orderConfirmationPage = new MKOrderConfirmationPage(driver);
        }

        [Given(@"I am on the receipt page")]
        public void GivenIAmOnTheReceiptPage()
        {
            driver.Navigate().GoToUrl(MKProductPage.URL);
            //Pause for popup transition
            System.Threading.Thread.Sleep(3000);
            MKProductPage productPage = new MKProductPage(driver);

            productPage.closePopup.Click();
            //Pause for popup transition
            System.Threading.Thread.Sleep(3500);

            productPage.addToCartButton.Click();
            //Wait for popup to be displayed
            System.Threading.Thread.Sleep(1000);

            productPage.popupViewCartCheckoutButton.Click();
            MKShoppingCartPage shoppingCartPage = new MKShoppingCartPage(driver);
            shoppingCartPage.checkoutButton.Click();

            MKLoginPage loginPage = new MKLoginPage(driver);
            loginPage.checkoutAsGuestButton.Click();

            MKCheckoutPage1 checkoutPage1 = new MKCheckoutPage1(driver);
            checkoutPage1.completeForm();

            checkoutPage1.proceedToPaymentAndReviewButton.Click();
            //Wait for form submit
            System.Threading.Thread.Sleep(2000);

            MKCheckoutPage2 checkoutPage2 = new MKCheckoutPage2(driver);
            checkoutPage2.completePaymentInfo();
            checkoutPage2.submitOrderButton.Click();
            //Wait for form submit
            System.Threading.Thread.Sleep(2000);

            MKOrderConfirmationPage orderConfirmationPage = new MKOrderConfirmationPage(driver);
            ScenarioContext.Current["orderConfirmationPage"] = orderConfirmationPage;
        }

        [When(@"I close the popups")]
        public void WhenICloseThePopups()
        {
            MKOrderConfirmationPage orderConfirmationPage = (MKOrderConfirmationPage)ScenarioContext.Current["orderConfirmationPage"];
            orderConfirmationPage.closePopupWindows();
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
