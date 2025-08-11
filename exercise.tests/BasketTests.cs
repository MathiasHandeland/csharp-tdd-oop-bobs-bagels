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
        Assert.That(basket.basketItems[0].Name, Is.EqualTo("Onion Bagel"));
    }

    [Test]
    public void RemoveBagelFromBasket()
    {
        // arrange
        Basket basket = new Basket();
        IProduct onionBagel = new Bagel("Onion");
        basket.AddProduct(onionBagel);
        
        // act
        basket.RemoveProduct("BGLO");
        
        // assert
        Assert.That(basket.basketItems.Count, Is.EqualTo(0));
    }
}