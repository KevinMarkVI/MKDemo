Feature: MK end to end test case
	Tests the entire flow from beginning to end


Scenario: Paua Shamrock Earrings End to End
	Given I am on the product page
	And I check for the Free Shipping popup
	And I continue to the Shopping Cart Page
	And I continue on to the first Checkout Page
	And I continue on to the second checkout page
	And I continue on to the Order Confirmation page
	When I close the popups
	Then I will have completed the purchase