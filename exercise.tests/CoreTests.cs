using exercise.main;
using exercise.main.Products;

namespace exercise.tests;

public class CoreTests
{

    [Test] // user story 1
    public void AddBagelToBasket()
    {
        // arrange
        Basket basket = new Basket();
        IProduct onionBagel = new Bagel("BGLO"); // adds a specific Bagel variant (onion bagel)

        // act
        basket.AddProduct(onionBagel);

        // assert
        Assert.That(basket.basketItems.Count, Is.EqualTo(1));
        Assert.That(basket.basketItems[0].Id, Is.EqualTo("BGLO"));
    }

    [Test] // user story 2
    public void RemoveBagelFromBasket()
    {
        // arrange
        Basket basket = new Basket();
        IProduct onionBagel = new Bagel("BGLO");
        basket.AddProduct(onionBagel);
        
        // act
        basket.RemoveProduct("BGLO"); // removes the Bagel with ID "BGLO"

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

    [Test] // user story 5
    public void RemoveNonExistentProduct()
    {
        // arrange
        Basket basket = new Basket();
        basket.AddProduct(new Bagel("BGLS")); // adds a sesame bagel to basket

        // act & assert
        Assert.Throws<ArgumentException>(() => basket.RemoveProduct("BGLO")); // removing a non-present onion bagel is not allowed
    }

    [Test] // user story 6
    public void BasketTotal()
    {
        // arrange
        Basket basket = new Basket();
        basket.AddProduct(new Bagel("BGLO"));
        basket.AddProduct(new Bagel("BGLP"));
        basket.AddProduct(new Bagel("BGLS"));

        // act
        decimal basketTotal = basket.BasketTotal;

        // assert
        Assert.That(basketTotal != 0);
        Assert.That(basketTotal, Is.EqualTo(1.37m)); // 0.49 + 0.39 + 0.49 = 1.37
    }

    [Test] // user story 7
    public void BagelPrice()
    {
        // arrange
        Bagel onionBagel = new Bagel("BGLO");
        Bagel plainBagel = new Bagel("BGLP");
        Bagel everythingBagel = new Bagel("BGLE");
        Bagel sesameBagel = new Bagel("BGLS");

        // act and assert
        Assert.That(onionBagel.Price, Is.EqualTo(0.49m));
        Assert.That(plainBagel.Price, Is.EqualTo(0.39m));
        Assert.That(everythingBagel.Price, Is.EqualTo(0.49m));
        Assert.That(sesameBagel.Price, Is.EqualTo(0.49m));
    }

    [Test] // user story 8
    public void ChooseBagelFilling()
    {
        // arrange
        Filling baconFilling = new Filling("FILB");
        Bagel onionBagel = new Bagel("BGLO");

        // act 
        onionBagel.Filling = baconFilling;

        // assert
        Assert.That(onionBagel.Filling, Is.EqualTo(baconFilling));
    }

    [Test] // user story 9
    public void FillingPrice()
    {
        // arrange
        Filling baconFilling = new Filling("FILB");
        Filling eggFilling = new Filling("FILE");
        Filling cheeseFilling = new Filling("FILC");
        Filling creamyCheeseFilling = new Filling("FILX");
        Filling hamFilling = new Filling("FILH");

        // act and assert
        Assert.That(baconFilling.Price, Is.EqualTo(0.12m));
        Assert.That(eggFilling.Price, Is.EqualTo(0.12m));
        Assert.That(cheeseFilling.Price, Is.EqualTo(0.12m));
        Assert.That(creamyCheeseFilling.Price, Is.EqualTo(0.12m));
        Assert.That(hamFilling.Price, Is.EqualTo(0.12m));
    }

}