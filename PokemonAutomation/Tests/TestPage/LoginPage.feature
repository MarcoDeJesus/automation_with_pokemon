Feature: LoginPage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: User should be redirected to Secure page after login
	Given that the test user is in the System Login page
	And the test user provides a username of 'tomsmith'
	And the test user provides a password of 'SuperSecretPassword!'
	When the test clicks the login button
	Then page user should be redirected to the secure page
	And the page should display the message 'You logged into a secure area!'


Scenario Outline: Login page should display error messages for invalid credentials
	Given that the test user is in the System Login page
	And the test user provides this '<username>' as username and this '<password>' as password
	When the test clicks the login button
	Then page should display an error message on top with the text '<text>'

	Examples:
	| username        | password        | text                      |
	| invalidUsername | invalidPassword | Your username is invalid! |
	| invalidUsername | SuperSecretPassword! |  Your username is invalid! |
	| tomsmith | wronmgpassword |  Your password is invalid! |


Scenario: Login action with no credential should return an error messasge
	Given that the test user is in the System Login page
	When the test clicks the login button
	Then page should display an error message on top with the text 'Your username is invalid!'


Scenario: Loging out from the secure area should redirect the user to the login page
	Given that the test user has performed a valid login
	When the test user clicks the Logout button
	Then the system will redirect the user to the System Login page


Scenario: Navigation to the Secure page without providing credentials should redirect the user to login page
	Given that the test has navigates to the secure page directl
	Then the system will redirect the user to the System Login page