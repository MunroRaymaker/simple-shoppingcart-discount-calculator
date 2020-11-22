# Simple Shoppingcart Discount Calculator
A simple discount calculator for a shopping cart.  This is a coding challenge where we must implement a simple promotion rule engine for a checkout process.

The cart contains a list of single character SKU ids, eg. A, B, C, D over which the promotion engine must run.

The promotion engine should calculate the total order value, after applying two promotion codes.

* Buy N items for a fixed price
* Buy two different SKUs for a fixed price

The promotion types should be modular to allow for more discount types to be added at a later date, eg. a promotion could be a % of the normal price.

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

Promotions should be mutually exclusive, meaning that there can only be one discount for a given sku. A sku can onkly exist in one promotion.

The unit tests will test these scenarios. 

As a bonus, there's also included a percentage promotion in this solution. This applies to a new product E.

# vNext
The solution could be enhanced with a rules engine where each promotion could be iterated on the entire shopping cart, instead of relying on a growing switch statement.
Another posibility is to abstract the logic in the shoppingcart totalizer to dedicated discount classes. Each discount type could have it's own class with logic to calculate the deduction for that promotion.

More discount types could also be added, like buy for X amount and get an item free, or qualify for free shipping.
A percentage discount for the entire cart could also be added, if the total sum is greater than x.
