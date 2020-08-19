Feature: Pokemon_Class
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given the test user has selects '<name>' as the test Pokemon
	When the test user generates an instance using only the IsShiny flag as '<state>'
	Then the result Pokemon should '<isShiny>' be shiny

	Examples: 
	| name   | state    | isShiny |
	| Mewtwo | enabled  | yes     |
	| Mewtwo | disabled | no      |