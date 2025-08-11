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
        IProduct onionBagel = new Bagel("Onion");

        // act
        basket.AddProduct(onionBagel);

        // assert
        Assert.That(basket.basketItems.Count, Is.EqualTo(1));
        Assert.That(basket.basketItems[0].Name, Is.EqualTo("Onion Bagel"));
    }
}