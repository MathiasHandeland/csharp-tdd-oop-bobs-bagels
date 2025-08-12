using exercise.main;
using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class ConsoleReceiptPrinterTests
    {
        [Test] // user story 11, printing receipt to console works
        public void PrintReceipt()
        {
            // arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket(inventory);
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            ConsoleReceiptPrinter receipt = new ConsoleReceiptPrinter(basket);

            // redirect console output
            var output = new StringWriter();
            Console.SetOut(output);

            // act
            receipt.Print();

            // assert
            string printed = output.ToString();
            Assert.IsNotEmpty(printed); // Check that something actualy was printed
            Assert.That(printed, Does.Contain("Bob's Bagels")); 
        }
    }
}