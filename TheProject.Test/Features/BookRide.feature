Feature: BookRide
	So that I can get from a to b
	As Pat
	I want to book a ride

@mytag
Scenario: Pat books a ride with Charlie
	Given Pat is a registered customer
	And Charlie is a registered driver
	When Pat books a ride
	Then Charlie is booked to Pat
