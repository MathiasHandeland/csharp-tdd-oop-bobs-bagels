
using exercise.main;
using exercise.main.Products;

Inventory inventory = new Inventory();
Basket basket = new Basket(inventory);
basket.AddProduct(new Bagel("BGLO"));

Receipt receipt = new Receipt(basket);
receipt.Print();