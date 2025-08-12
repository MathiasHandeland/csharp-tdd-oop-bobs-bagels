using exercise.main;
using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class DiscountExtentionTests
    {
        [Test] // user story 12, Every Bagel should be available for the 6 for £2.49. Must be 6 with same SKU
        public void BuyingSixBagels()
        {
            // arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket(inventory);
            basket.BasketCapacity = 10; // must adjust basket capacity
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));

            // act & assert
            Assert.That(basket.BasketTotal, Is.EqualTo(2.49)); // True if discount was added
        }

        [Test] // user story 12, Every Bagel should be available for the 12 for £3.99. Must be 12 with same SKU
        public void BuyingTwelveBagels()
        {
            // arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket(inventory);
            basket.BasketCapacity = 12; // must adjust basket capacity
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));

            // act & assert
            Assert.That(basket.BasketTotal, Is.EqualTo(3.99)); // True if discount was added
        }

        [Test] // user story 12, Full order discount test
        public void DiscountedOrder1()
        {
            // arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket(inventory);
            basket.BasketCapacity = 30; // must adjust basket capacity
            // add 2 onion bagels: price is 0.98 for 2
            basket.AddProduct(new Bagel("BGLO"));
            basket.AddProduct(new Bagel("BGLO"));
            // add 12 plain bagels: price is 3.99 for 12
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
            // add 6 everything bagels: price is 2.49 for 6
            basket.AddProduct(new Bagel("BGLE"));
            basket.AddProduct(new Bagel("BGLE"));
            basket.AddProduct(new Bagel("BGLE"));
            basket.AddProduct(new Bagel("BGLE"));
            basket.AddProduct(new Bagel("BGLE"));
            basket.AddProduct(new Bagel("BGLE"));
            // add 3 black coffees: price is 2.97 for 3
            basket.AddProduct(new Coffee("COFB"));
            basket.AddProduct(new Coffee("COFB"));
            basket.AddProduct(new Coffee("COFB"));

            // act & assert
            Assert.That(basket.BasketTotal, Is.EqualTo(10.43)); // True if discount was added
        }

        [Test] // user story 12, Full order discount test
        public void DiscountedOrder2()
        {
            // arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket(inventory);
            basket.BasketCapacity = 30; // must adjust basket capacity
            // add 16 plain bagels: price is £3.99 for 12 and £0.39 for each additional bagel
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
            basket.AddProduct(new Bagel("BGLP"));
            basket.AddProduct(new Bagel("BGLP"));
            basket.AddProduct(new Bagel("BGLP"));
            basket.AddProduct(new Bagel("BGLP"));

            // act & assert
            Assert.That(basket.BasketTotal, Is.EqualTo(5.55)); // True if discount was added
        }
    }
}
