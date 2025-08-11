using exercise.main;
using exercise.main.Products;

namespace exercise.tests;

public class BasketTests
{

    [Test] // user story 1
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

    [Test] // user story 2
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

    [Test] // user story 3
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

    [Test] // user story 3
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

    [Test] // user story 4
    public void BasketCapacityCanBeSet()
    {
        // arrange
        Basket basket = new Basket();
        
        // act
        basket.BasketCapacity = 10;
        
        // assert
        Assert.That(basket.BasketCapacity, Is.EqualTo(10));
    }

    [Test] // user story 4
    public void BasketCapacityCannotBeSetToZeroOrNegative()
    {
        // arrange
        Basket basket = new Basket();
        
        // act & assert
        Assert.Throws<ArgumentException>(() => basket.BasketCapacity = 0);
        Assert.Throws<ArgumentException>(() => basket.BasketCapacity = -5);
    }
}