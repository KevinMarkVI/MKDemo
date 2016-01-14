Feature: My Account Login Error Testing
	Verify the behavior of Accout Login Flow

Scenario: Navigate to the My Account Page
	Given I am on the Miles Kimball homepage
	And I dismiss the Free Shipping popup
	When I Click on the My Account Link
	Then I should be on the Account Login Page

Scenario: Entering an Invalid Email should Display an Error
	Given I am on the MK Account Login Page
	And I dismiss the Free Shipping popup
	When I enter the email address 'SSBtestautomation@gmail' and the password 'SSBtest10'
	Then I should see the Invalid Username and Password Error

Scenario: Entering an Invalid Password should Display an Error
	Given I am on the MK Account Login Page
	And I dismiss the Free Shipping popup
	When I enter the email address 'SSBtestautomation@gmail.com' and the password 'SSBtest10'
	Then I should see the Invalid Username and Password Error

Scenario: After Entering a Valid Email and Password I should see the Account Page
	Given I am on the MK Account Login Page
	And I dismiss the Free Shipping popup
	When I enter the email address 'SSBtestautomation@gmail.com' and the password 'SSBtest100'
	Then I should be on the My Account Page