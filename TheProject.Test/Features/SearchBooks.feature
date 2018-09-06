Feature: SearchBook
	In order to search for a book
	As a member
	I want to get a list of all books

@mytag
Scenario: Get all books
	Given we have the following books in the stock:
| BookId | Title             | ISBN      | Status    |
| 1      | Harry Potter      | 123512353 | Available |
| 2      | Lord of the rings | 123512358 | Available |
| 3      | Game of thrones   | 123512358 | Borrowed  |
	When I request all books
	Then the result should be 
| BookId | Title             | ISBN      | Status    |
| 1      | Harry Potter      | 123512353 | Available |
| 2      | Lord of the rings | 123512358 | Available |
| 3      | Game of thrones   | 123512358 | Borrowed  |
