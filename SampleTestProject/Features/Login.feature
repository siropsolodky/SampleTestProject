Feature: Login
	
Scenario: Login successful
	Given Login service address https://reqres.in
	When Login by credentials
		| Email              | password   |
		| eve.holt@reqres.in | cityslicka |
	Then Login token obtained
	
Scenario Outline: Login failed
	Given Login service address https://reqres.in
	When Login by credentials
		| Email   | password   |
		| <email> | <password> |
	Then Login token not obtained
Examples:
	| email              | password    |
	| eve.holt@reqres.in | notpassword |
	| wrong              | cityslicka  |
