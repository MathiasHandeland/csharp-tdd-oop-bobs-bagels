using exercise.main;
using exercise.main.Products;

namespace exercise.tests;

public class BasketTests
{

    [Test]
    public void AddBagelToBasket()
    {
        // arrange
        Basket basket = new Basket();
        IProduct onionBagel = new Bagel("Onion"); // adds a specific variant of Bagel

        // act
        basket.AddProduct(onionBagel);

        // assert
        Assert.That(basket.basketItems.Count, Is.EqualTo(1));
        Assert.That(basket.basketItems[0].Variant, Is.EqualTo("Onion"));
    }

    [Test]
    public void RemoveBagelFromBasket()
    {
        // arrange
        Basket basket = new Basket();
        IProduct onionBagel = new Bagel("Onion", "BGLO");
        basket.AddProduct(onionBagel);
        
        // act
        basket.RemoveProduct("BGLO");
        
        // assert
        Assert.That(basket.basketItems.Count, Is.EqualTo(0));
    }

    [Test]
    public void BasketIsFull()
    {
        // arrange
        Basket basket = new Basket();
        basket.AddProduct(new Bagel("Onion"));
        basket.AddProduct(new Bagel("Sesame"));
        basket.AddProduct(new Bagel("Sesame"));
        basket.AddProduct(new Bagel("Plain"));
        basket.AddProduct(new Bagel("Sesame"));
        
        // act
        bool isFull = basket.IsFull;
        
        // assert
        Assert.That(isFull, Is.True);
    }

    [Test]
    public void BasketIsNotFull()
    {
        // arrange
        Basket basket = new Basket();
        basket.AddProduct(new Bagel("Onion"));
        basket.AddProduct(new Bagel("Sesame"));
        basket.AddProduct(new Bagel("Sesame"));
        basket.AddProduct(new Bagel("Plain"));

        // act
        bool isFull = basket.IsFull;

        // assert
        Assert.That(isFull, Is.False);
    }
}