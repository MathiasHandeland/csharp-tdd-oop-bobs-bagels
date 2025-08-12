
using exercise.main;
using exercise.main.Products;
using System.Reflection.Metadata;

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

// Should print something like this
//    ~~~Bob's Bagels ~~~

//    2021 - 03 - 16 21:38:44

//----------------------------

//Onion Bagel        2   £0.98
//Plain Bagel        12  £3.99
//Everything Bagel   6   £2.49
//Black Coffee       3   £2.97

//----------------------------
//Total                 £10.43

//        Thank you
//      for your order!