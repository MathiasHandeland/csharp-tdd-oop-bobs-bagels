# Bob's Bagels - Object-oriented Programming


## Domain Model of User stories

```
1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.
```
| Classes      | Methods/Properties           | Scenario                                  | Outputs         |
|--------------|------------------------------|-------------------------------------------|-----------------|
| Basket       | AddProduct(IProduct product) | Add a bagel to basket (list of bagels)    | bool            |

```
2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.
```
| Classes      | Methods/Properties               | Scenario                                      | Outputs         |
|--------------|----------------------------------|-----------------------------------------------|-----------------|
| Basket       | RemoveProduct(string productId)  | Remove a bagel from basket (list of bagels)   | bool            |

```
3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
```
| Classes      | Methods/Properties               | Scenario                                                      | Outputs         |
|--------------|----------------------------------|---------------------------------------------------------------|-----------------|
| Basket       | IsFull (property)                | Check if basket item count exceeds basket capacity            | bool            | 
| Basket       | AddProduct(IProduct product)     | Throws expection when trying to add product to full basket    | exception       |

```
4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.
```
| Classes      | Methods/Properties               | Scenario                                                      | Outputs          |
|--------------|----------------------------------|---------------------------------------------------------------|------------------|
| Basket       | BasketCapacity (property)        | Set basket capacity to value. Throw exception if value <= 0   | int or exception |  

```
5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.
```
| Classes      | Methods/Properties               | Scenario                                                                         | Outputs         |
|--------------|----------------------------------|----------------------------------------------------------------------------------|-----------------|
| Basket       | RemoveProduct (string productId) | Throw exception when a product not present in basket is tried being removed      | exception       |  

```
6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.
```
| Classes      | Methods/Properties               | Scenario                                     | Outputs         |
|--------------|----------------------------------|----------------------------------------------|-----------------|
| Basket       | BasketTotal (property)           | Return the total cost of products in basket  | decimal         |  

```
7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.
```
| Classes      | Methods/Properties        | Scenario                                     | Outputs         |
|--------------|---------------------------|----------------------------------------------|-----------------|
| Bagel        | Price (property)          | Return the price of the bagel                | decimal         |  

```
8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.
```
| Classes      | Methods/Properties                                                   | Scenario                                                                      | Outputs                                           |
|--------------|----------------------------------------------------------------------|-------------------------------------------------------------------------------|---------------------------------------------------|
|  Bagel       |  AddFillings(IEnumerable<Filling> fillings, Inventory inventory)     | Adds one or multiple fillings if the fillings are in inventory bagel filling  | void (Bagel.Fillings updated or exception thrown  |  

```
9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.
```
| Classes      | Methods/Properties        | Scenario                                        | Outputs         |
|--------------|---------------------------|-------------------------------------------------|-----------------|
|  Filling     |  Price (property)         | Returns the price of the filling bagel filling  | decimal         |  

```
10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.
```
| Classes      | Methods/Properties          | Scenario                                                                                                | Outputs      |
|--------------|-----------------------------|---------------------------------------------------------------------------------------------------------|--------------|
|  Inventory   |  IsInInventory              | Before adding a bagel/coffee to the basket we check that the bagel/coffee variant is in the inventory   | bool         |  
|  Inventory   |  IsInInventory              | Before adding a filling to a bagel we check that the filling variant is in the inventory                | bool         |  

### RECEIPT EXTENTION
```
11.
As a customer,
So I can track what I spend money on,
I want to revieve a receipt to my order.
```
| Classes  | Methods/Properties                | Scenario                                 | Outputs         |
|----------|-----------------------------------|------------------------------------------|-----------------|
| Receipt  | Print()                           | Print the receipt to the terminal        | void            |
| Receipt  | Items (List<IProduct>)            | List of items added to the basket        | List<IProduct>  |
| Receipt  | TotalPrice (decimal)              | Total cost of the order                  | decimal         |
| Receipt  | Timestamp (DateTime)              | When the order was placed                | DateTime        |
| Receipt  | ReceiptNumber (string/int)        | Unique identifier for the receipt        | string/int      |