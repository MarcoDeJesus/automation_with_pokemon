Feature: Pokemon_Class
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Setting the "IsShiny" flag should produce shiny or non shiny pokemon
	Given that the test user has selects '<name>' as the test Pokemon
	When the test user generates an instance using only the IsShiny flag as '<state>'
	Then the result Pokemon should '<isShiny>' be shiny

	Examples: 
	| name   | state    | isShiny |
	| Mewtwo | enabled  | yes     |
	| Mewtwo | disabled | no      |


Scenario: HP - Adding more than 252 EV points in a status should be ignored - No points
	Given that the test user has selects 'Mewtwo' as the test Pokemon
	And that the test user generates a Pokemon instance
	When the test user adds '253' EV points to the HP stat
	Then HP stat should have '0' EV points


Scenario: HP - Adding more than 252 EV points in a status should be ignored - Points allocated
	Given that the test user has selects 'Mewtwo' as the test Pokemon
	And that the test user generates a Pokemon instance
	And that the test user adds '200' EV points to the HP stat
	When the test user adds '253' EV points to the HP stat
	Then HP stat should have '200' EV points


Scenario: HP - Adding valid HP EV points
	Given that the test user has selects 'Mewtwo' as the test Pokemon
	And that the test user generates a Pokemon instance
	And that the test user adds '100' EV points to the HP stat
	When the test user adds '152' EV points to the HP stat
	Then HP stat should have '252' EV points


Scenario: HP - Reseting EV points should set HP EVs points to 0
	Given that the test user has selects 'Mewtwo' as the test Pokemon
	And that the test user generates a Pokemon instance
	And that the test user adds '100' EV points to the HP stat
	When the test user resets the Pokemon EVs
	Then HP stat should have '0' EV points