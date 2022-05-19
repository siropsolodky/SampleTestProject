Feature: Product

Scenario: Products successful
	Given Product service address https://reqres.in
	When Get Products
	Then Products year equal or above 2000
