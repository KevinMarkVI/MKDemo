Feature: MK Individual Tests
	Scenarios designed to test single aspect of the Miles Kimball Website

Scenario: Confirm Alert is present on homepage
	Given I am on the Miles Kimball homepage
	Then the free shipping alert should be present

Scenario: Confirm Alert is Present and Dismiss
	Given I am on the Miles Kimball homepage
	And the Free Shipping alert Appears
	And I dismiss the Free Shipping popup
	Then the alert should not be present

Scenario: Search for Paua Shamrock Earrings
	Given I am on the Miles Kimball homepage
	And I check for the Free Shipping popup on the home page
	When I enter the SKU in the search box and submit
	Then I should be on the Paua Shamrock product page

Scenario: Add Paua Shamrock Earrings to Cart and Confirm Popup Info
	Given I am on the product page
	And I check for the Free Shipping popup
	When I click the Add to Cart Button
	Then the popup should appear with the correct information

Scenario: Add Paua Shamrock Earrings to Cart click Popup and Confirm Shopping Cart Page Load
	Given I am on the product page
	And I check for the Free Shipping popup
	When I click the Add to Cart Button
	When I click the View Cart / Checkout Button
	Then I should be on the shopping cart page 

Scenario: Verify information on the Shopping Cart Page
	Given I am on the product page
	And I check for the Free Shipping popup
	And I continue to the Shopping Cart Page
	Then The expected information should be present

Scenario: Navigate to the Login Page and Verify Checkout as Guest button
	Given I am on the product page
	And I check for the Free Shipping popup
	And I continue to the Shopping Cart Page
	When I click on the Checkout button	
	Then I should see the Checkout as Guest Button

Scenario: Navigate to CheckoutPage1
	Given I am on the product page
	And I check for the Free Shipping popup
	And I continue to the Shopping Cart Page
	When I click on the Checkout button	
	When I click on the Checkout as Guest Button
	Then I should be on the first Checkout Page

Scenario: Verify Summary Information on Checkout Page 1
	Given I am on the product page
	And I check for the Free Shipping popup
	And I continue to the Shopping Cart Page
	And I continue on to the first Checkout Page
	Then I will confirm the summary information

Scenario: Complete Checkout Page 1 and Submit
	Given I am on the product page
	And I check for the Free Shipping popup
	And I continue to the Shopping Cart Page
	And I continue on to the first Checkout Page
	When I complete the form and confirm order summary information
	When I click the Proceed to Payment and Review Button
	Then I should be on the second checkout page

Scenario: Confrim Order Summary information on Checkout Page2
	Given I am on the product page
	And I check for the Free Shipping popup
	And I continue to the Shopping Cart Page
	And I continue on to the first Checkout Page
	And I continue on to the second checkout page
	Then the correct information should be present

Scenario: Complete Payment Information and Submit Order
	Given I am on the product page
	And I check for the Free Shipping popup
	And I continue to the Shopping Cart Page
	And I continue on to the first Checkout Page
	And I continue on to the second checkout page
	When I fill complete the payment information
	When I click the submit order button
	Then I should be on the Order Confirmation page

Scenario: Dismiss all the Popup Windows to get to the Order Confirmation Page
	Given I am on the product page
	And I check for the Free Shipping popup
	And I continue to the Shopping Cart Page
	And I continue on to the first Checkout Page
	And I continue on to the second checkout page
	And I continue on to the Order Confirmation page
	When I close the popups
	Then they should not be present

Scenario: Confirm Information on the Receipt Page
	Given I am on the product page
	And I check for the Free Shipping popup
	And I continue to the Shopping Cart Page
	And I continue on to the first Checkout Page
	And I continue on to the second checkout page
	And I continue on to the Order Confirmation page
	When I close the popups
	Then I will confirm all the pertinent information
