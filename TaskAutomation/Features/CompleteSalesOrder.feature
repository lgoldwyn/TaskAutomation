Feature: Complete Sales Order
	Create a complete Sales Order flow and verify the available stock on hand of the product.
	
Scenario: Create a new Sales Order and validate the product quanitity
	Given Login to Unleashes
	And Add a new product
	And Create a new Purchase Order
	And Receipt of Purchase order successfully
	And Create a Sales Order
	When Check product from View product page 
	Then Product quantity on stock is correctly updated 

