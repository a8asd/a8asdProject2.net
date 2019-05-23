Feature: PayForRide
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Pat pays for a ride
	Given Pat has travelled 10 miles with Charlie
	Given Pat has travelled 25 miles with Charlie
	Given Pat has travelled 35 miles with Charlie
	Given these journeys
		| payee | driver  | distance |
		| Pat   | Charlie | 10       |
		| Pat   | Charlie | 25       |
		| Pat   | Charlie | 35       |
	And the rate is £2 per mile
	And the rates are
		| miles | amount per mile |
		| 10    | 2.00            |
		| 20    | 1.50            |
		| 30    | 1               |
	When Pat pays for the ride
	Then these are the invoices in the system
		| payee | driver  | distance | amount |
		| Pat   | Charlie | 10       | 20.00  |