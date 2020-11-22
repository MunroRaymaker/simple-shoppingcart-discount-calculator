# Simple Shoppingcart Discount Calculator
A simple discount calculator for a shopping cart.  This is a coding challenge where we must implement a simple promotion rule engine for a checkout process.

The cart contains a list of single character SKU ids, eg. A, B, C, D over which the promotion engine must run.

The promotion engine should calculate the total order value, after applying two promotion codes.

* Buy N items for a fixed price
* Buy two different SKUs for a fixed price

The promotion types should be modular to allow for more dicount types to be added at a later date, eg. a promotion could be a % of the normal price.

# Test setup
There are four products with these SKU ids and unit prices:
* A 50
* B 30
* C 20
* D 15

## Active promotions
* 3 A's for 130
* 2 B's for 45
* C+D for 30

