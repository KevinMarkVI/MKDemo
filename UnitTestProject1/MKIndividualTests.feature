Feature: MK Individual Tests
	Scenarios designed to test single aspect of the Miles Kimball Website


Scenario: Confirm Alert is Present and Dismiss
	Given I am on the Miles Kimball homepage
	And the Free Shipping alert Appears
	When I dismiss the popup
	Then the alert should not be present

Scenario: Search for Paua Shamrock Earrings
	Given I am on the Miles Kimball homepage
	And I dismiss the Free Shipping popup
	When I enter the SKU in the search box and submit
	Then I should be on the Paua Shamrock product page

Scenario: Add Paua Shamrock Earrings to Cart and Confirm Popup Info
	Given I am on the product page
	And I dismiss the Free Shipping popup
	When I click the Add to Cart Button
	Then the popup should appear with the correct information

Scenario: Add Paua Shamrock Earrings to Cart click Popup and Confirm Shopping Cart Page Load
	Given I am on the product page
	And I dismiss the Free Shipping popup
	When I click the Add to Cart Button
	When I click the View Cart / Checkout Button
	Then I should be on the shopping cart page 

Scenario: Verify information on the Shopping Cart Page
	Given I am on the Shopping Cart Page
	Then The expected information should be present

Scenario: Navigate to the Login Page and Verify Checkout as Guest button
	Given I am on the Shopping Cart Page
	When I click on the Checkout button	
	Then I should see the Checkout as Guest Button

Scenario: Navigate to CheckoutPage1
	Given I am on the Shopping Cart Page
	When I click on the Checkout button	
	When I click on the Checkout as Guest Button
	Then I should be on the first Checkout Page

Scenario: Complete Checkout Page 1 and Submit
	Given I am on the first Checkout Page
	When I complete the form
	When I click the Proceed to Payment and Review Button
	Then I should be on the second checkout page







