Feature: AddProduct
	Adding new product from the Add Product page and verifying the added product from the View product page

@Task1 Create new product
Scenario: Add a new Product and validate it
	Given I have logged into Unleashed website successfully
	And I navigate to Add Product page
	When user enter values
	| Code  | Description |
	| TC | Coffee table    |
	And I press Save
	Then I search the View product page for the newly added product
