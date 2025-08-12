
using exercise.main;
using exercise.main.Products;

Inventory inventory = new Inventory();
Basket basket = new Basket(inventory);
basket.BasketCapacity = 50;

basket.AddProduct(new Bagel("BGLO"));
basket.AddProduct(new Bagel("BGLO"));
basket.AddProduct(new Bagel("BGLP"));
basket.AddProduct(new Bagel("BGLP"));
basket.AddProduct(new Bagel("BGLP"));
basket.AddProduct(new Bagel("BGLP"));
basket.AddProduct(new Bagel("BGLP"));
basket.AddProduct(new Bagel("BGLP"));
basket.AddProduct(new Bagel("BGLP"));
basket.AddProduct(new Bagel("BGLP"));
basket.AddProduct(new Bagel("BGLP"));
basket.AddProduct(new Bagel("BGLP"));
basket.AddProduct(new Bagel("BGLP"));
basket.AddProduct(new Bagel("BGLP"));
basket.AddProduct(new Bagel("BGLE"));
basket.AddProduct(new Bagel("BGLE"));
basket.AddProduct(new Bagel("BGLE"));
basket.AddProduct(new Bagel("BGLE"));
basket.AddProduct(new Bagel("BGLE"));
basket.AddProduct(new Bagel("BGLE"));
basket.AddProduct(new Coffee("COFB"));
basket.AddProduct(new Coffee("COFB"));
basket.AddProduct(new Coffee("COFB"));

// Can change which receipt printer to use, either console or twilio
IReceiptPrinter consoleReceipt = new ConsoleReceiptPrinter(basket);
consoleReceipt.Print();