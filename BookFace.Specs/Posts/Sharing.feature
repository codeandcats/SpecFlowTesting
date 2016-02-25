Feature: 
	In order to protect my privacy
	As a user
	I want only friends to see my posts

@SmokeTests
Scenario:
	Given the following users:

	| UserName | Friends       |
	| Joe      | Natalie, Fred |
	| Fred     | Joe           |
	| Natalie  | Joe           |

	When Joe creates a post shared with friends
	Then the following users should be able to see it
    And the following users should not be able to see it

    When Joe creates a post shared with public
    Then the following users should be able to see it