Feature: Book A Ride
In Order to get from a to b
As Pat
I want to Book a ride

Scenario: Pat books a ride with Charlie
Given Pat is a registered customer
And Charlie is an available driver
When Pat books a ride with Charlie
Then Charlie is booked to Pat