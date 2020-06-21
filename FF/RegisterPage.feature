Feature: RegisterPage
	In order to use Ankpro website
	I need to Login

@mytag
Scenario: InValid Login user
	Given I navigate to url
	| url                                 |
	| http://www.ankpro.com/Account/Login |
	#And I enter email
	#And I enter password
	And I enter email and password
	| Email       | Password |
	| Abc@abc.com | 123456   |
	And I click remenber me
	When I press login
	#Then i should not be loged in

	@mytag
Scenario Outline: Login user two
	Given I navigate to url
	| url                                 |
	| http://www.ankpro.com/Account/Login |
	#And I enter email
	#And I enter password
	And I enter <Email> and <Password>
	And I click remenber me
	When I press login
	#Then i should not be loged in

	Examples: 
	| Email       | Password |
	| Abc@abc.com | 123456   |
	| Bbc@bbc.com | 345678   |