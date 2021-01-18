Feature: Pokemon_Endpoint
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Check Pokemon API Returns the right information for each Pokemon
	Given that the user has selected the '<pokemon>' Pokemon
	When the test user queries the Pokemon API with the selected Pokemon
	Then The API response should include the name of the provided Pokemon
		And The API response should return the pokemon number as '<number>'
		And The API response should return the pokemon Base HP as as '<hp>'
		And The API response should return the pokemon Base Attack as as '<att>'
		And The API response should return the pokemon Base Defense as as '<def>'
		And The API response should return the pokemon Base Special Attack as as '<sp.att>'
		And The API response should return the pokemon Base Special Defense as as '<sp.def>'
		And The API response should return the pokemon Base Speed as as '<speed>'

		Examples: 
		| pokemon | number | hp  | att | def | sp.att | sp.def | speed |
		| mewtwo  | 150    | 106 | 110 | 90  | 154    | 90     | 130   |
		| mewtwo  | 150    | 106 | 110 | 90  | 154    | 90     | 131   |
