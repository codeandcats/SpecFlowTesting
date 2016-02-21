Feature: Calculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@SmokeTest
Scenario: Add two numbers
	Given I have entered 1234567
	And I press the Plus key
	And I have entered 6773568
	When I press the Equals key
	Then it should display 8008135
