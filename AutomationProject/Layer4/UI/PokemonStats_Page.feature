Feature: PokemonStats_Page
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: The Data from Pokemon API should match the Pokemon DataBase detail page
	Given that the test user has selected a the '<name>' Pokemon for this test
		And that the test user has navigated to the Pokemon DataBase page
		And that the user has navigated to the National Pokedex List with the Quick Link in Home Page
	When the user selects the Test Pokemon from the list of Pokemon
	Then the Pokemon Pokedex entry should display the pokemon name in the header label
		#And the Pokemon Pokedex entry should display a correct primary type
		#And the Pokemon Pokedex entry should display a correct secondary type
		And the Pokemon Pokedex entry should display a correct Base HP stat value
		And the Pokemon Pokedex entry should display a correct Base Attack stat value
		And the Pokemon Pokedex entry should display a correct Base Defense stat value
		And the Pokemon Pokedex entry should display a correct Base Sp. Attack stat value
		And the Pokemon Pokedex entry should display a correct Base Sp. Defense stat value
		And the Pokemon Pokedex entry should display a correct Base Speed stat value

	Examples: 
	| name      |
	| Mewtwo    |
	| Dragonite |
