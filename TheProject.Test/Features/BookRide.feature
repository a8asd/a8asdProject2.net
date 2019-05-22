Feature: Book A Ride
In Order to get from a to b
As Pat
I want to Book a ride

Scenario: Pat books a ride with Charlie
Given Pat is a registered customer
And David is a registered customer
And Charlie is an available driver
When Pat books a ride with Charlie
And David books a ride with Charlie
Then these are the bookings
| driver  | customer |
| Charlie | Pat      |
| Charlie | David    |