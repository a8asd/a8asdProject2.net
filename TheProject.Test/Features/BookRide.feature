Feature: Book A Ride
In Order to get from a to b
As Pat
I want to Book a ride

Background:
	Given Pat is a registered customer
	And TargetRadius is 200
	And Charlie is an available driver at 100, 100
	And Fred is an available driver at 1000, 1000


Scenario: Pat books a ride with Charlie
	Given Vidya is a registered customer
	And David is a registered customer
	When Vidya books a ride with Charlie
	And David books a ride with Charlie
	Then these are the bookings
		| driver  | customer |
		| Charlie | Vidya    |
		| Charlie | David    |

Scenario: Pat requests offers
	When Pat requests offers from 10, 10
	Then these are the offers
		| driver  | distance |
		| Charlie | 127      |