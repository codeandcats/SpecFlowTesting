Feature: 
	In order to protect my privacy
	As a BookFace user
	I want to be able to restrict who can see my posts when I post them

@SmokeTests
Scenario: Post with privacy settings
	Given the following users:

	| UserName  | FriendNames  |
	| Joe       | Natalie, Fred |
	| Fred      | Joe           |
	| Natalie   | Joe           |

	When Fred creates a post shared with friends

	Then the following users should be able to see it

    | UserName |
	| Joe      |
	| Fred     |

    And the following users should not be able to see it

	| UserName |
    | Natalie  |

	When Joe creates a post shared with public

	Then the following users should be able to see it

    | UserName |
	| Joe      |
	| Fred     |
	| Natalie  |
