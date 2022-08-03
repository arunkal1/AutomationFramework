Feature: Assignment3
	Assignment 3: API Test Automation

@Assignment3
Scenario Outline: 01_APITestAutomation_CurrencyConversionRates
	Given the user send the following API Request
	| Key         | Value               |
	| requestType | GET                 |
	| baseUrl     | {{APIUrl}}          |
	| pathUrl     | /latest             |
	| queryParams | base=<baseCurrency> |
	When the request is completed and a response is returned
	Then the response status returned should be 'OK'

	Examples: 
	| baseCurrency |
	| USD          |
	| GBP          |
	| AED          |
	| CZK          |
	| HUF          |