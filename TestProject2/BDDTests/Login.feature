Feature: Login

Scenario: Varify user is logged in
	Given I load the website
	When I input username 
	And I input password
	Then I verify the user is logged in

Scenario: verify betslip is loaded
	Given I load the website
	When I input username 
	And I input password
	Then I verify betslip is present
