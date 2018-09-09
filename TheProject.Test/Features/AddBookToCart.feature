Feature: AddBookToCart
	In order to loan a book from library
	As a member
	I want to be able to add book into cart

@mytag
Scenario: Add book to cart
	Given I have an empty cart
	When I want to add the book clean code to my cart
	Then My cart should not be empty anymore
