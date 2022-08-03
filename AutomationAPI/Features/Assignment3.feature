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

@Assignment3
Scenario Outline: 02_APITestAutomation_StubReturnsResponse
	Given the user send the following API Request
	| Key         | Value               |
	| requestType | GET                 |
	| baseUrl     | {{APIUrl}}          |
	| pathUrl     | /latest             |
	| queryParams | base=<baseCurrency> |
	When the request is completed and a response is returned
	Then the response status returned should be 'OK'
	And the response content is stored in the database json file
	And the stub server is started
	And the user send the following API Request
	| Key           | Value                                             |
	| requestType   | POST                                              |
	| baseUrl       | {{StubAPIUrl}}                                    |
	| pathUrl       | /auth/login                                       |
	| requestBody   | {"email": "nilson@email.com","password":"nilson"} |
	And the request is completed and a response is returned
	And the response status returned should be 'OK'
	And the authentication token is returned
	And the user send the following API Request
	| Key           | Value          |
	| requestType   | GET            |
	| baseUrl       | {{StubAPIUrl}} |
	| pathUrl       | /exchangerates |
	| authenticated | Yes            |
	And the request is completed and a response is returned
	And the response status returned should be 'OK'
	And the stub server is ended

	Examples: 
	| baseCurrency |
	| USD          |
	| GBP          |