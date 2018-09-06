Feature: Checkout
	In order to borrow the books in my cart
	As a library member
	I want to be able to perform a checkout

@mytag
Scenario: Is there a book in the cart
	Given I am a library member
	And I have a cart with 0 items
	When I press checkout
	Then an error message "No books in cart" should be displayed
