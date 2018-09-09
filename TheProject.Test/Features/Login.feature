Feature: Login
	In to access the library facilities
	As Mikki
	I want to be able to login

Rules: Mikki can log in because they have a valid username and password

Scenario: Mikki Logs in successfully 
	Given Mikki is a member
	When Mikki logs in
	Then Mikki should be logged in
