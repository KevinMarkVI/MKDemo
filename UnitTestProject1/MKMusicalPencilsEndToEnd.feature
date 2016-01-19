Feature: Purchasing Musical Notes Pencils 
	Tests the entire flow from beginning to end

Scenario: End to End Musical Pencils Test Flow
	Given I am on the Miles Kimball homepage
	And I check for the Free Shipping popup on the home page
	And I click on Kids
	And I click on Pencils and Pencil Cases
	And I choose All from the Items per page selector
	And I click on the personalized musical notes pencils
	And I click personalize
	And I enter Mr. Rodgers neighborhood in the input
	And I click the personalization approval
	And I then click add to cart
	And I then click View Cart / Checkout
	And I enter the promotional code and apply
	And I choose premium shipping from the selector
	And I then click the bottom checkout button
	And I click the Checkout as Guest button
	And I complete the form accordingly
	And I uncheck the Special offers and emails box
	And I check the button to ship to a different address
	And I enter the additional address
	And I click the radio button to designate the item is a gift
	And I click the button to Proceed to payment and review
	And I fill out the payment information
	And I click the button to submit the order
	And I close all of the popup windows 
	Then I will be on the order confirmation page


