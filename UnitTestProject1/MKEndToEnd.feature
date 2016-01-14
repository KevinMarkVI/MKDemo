Feature: MK end to end test case
	Tests the entire flow from beginning to end


Scenario: End to End
	Given I am on the Miles Kimball website
	And I dismiss the popup
	And I search for Paua Shamrock Earrings using the SKU
	And I click add to cart
	And I click View Cart / Checkout
	And I click Checkout
	And I click Checkout as Guest
	And Complete the various fields
	And I click Proceed to Payment & Review
	And I enter payment information
	And I click Submit Order
	And I dismiss the popup windows
	Then the receipt page should confirm the order
