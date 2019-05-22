Feature: PayForRide
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Pat pays for a ride
	Given Pat has travelled 10 miles with Charlie
	And the rate is £2 per mile
	When Pat pays for the ride
	Then these are the invoices in the system
	| payee | driver  | distance | amount |
	| Pat   | Charlie | 10       | 20.00  |
