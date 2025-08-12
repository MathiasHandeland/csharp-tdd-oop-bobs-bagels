using exercise.main;
using exercise.main.Products;

namespace exercise.tests;

public class CoreTests
{

    [Test] // user story 1
    public void AddBagelToBasket()
    {
        // arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket(inventory);
        IProduct onionBagel = new Bagel("BGLO"); // adds a specific Bagel variant (onion bagel)

        // act
        basket.AddProduct(onionBagel);

        // assert
        Assert.That(basket.basketItems.Count, Is.EqualTo(1));
        Assert.That(basket.basketItems[0].Id, Is.EqualTo("BGLO"));
        Assert.That(basket.basketItems[0].Variant, Is.EqualTo("Onion"));
    }

    [Test] // user story 2
    public void RemoveBagelFromBasket()
    {
        // arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket(inventory);
        IProduct sesameBagel = new Bagel("BGLS");
        basket.AddProduct(sesameBagel);

        // assert that the sesame bagel is in the basket
        Assert.That(basket.basketItems.Count, Is.EqualTo(1));
        Assert.That(basket.basketItems, Does.Contain(sesameBagel));

        // act
        basket.RemoveProduct("BGLS"); // removes the Bagel with ID "BGLO"

        // assert
        Assert.That(basket.basketItems.Count, Is.EqualTo(0));
        Assert.That(basket.basketItems, Does.Not.Contain(sesameBagel));
    }

    [Test] // user story 3
    public void BasketIsFull()
    {
        // arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket(inventory);
        basket.AddProduct(new Bagel("BGLO"));
        basket.AddProduct(new Bagel("BGLS"));
        basket.AddProduct(new Bagel("BGLS"));
        basket.AddProduct(new Bagel("BGLP"));
        basket.AddProduct(new Bagel("BGLS"));
        
        // act
        bool isFull = basket.IsFull;
        
        // assert
        Assert.That(isFull, Is.True);
        Assert.Throws<InvalidOperationException>(() => basket.AddProduct(new Bagel("BGLE"))); // trying to add another bagel should throw an exception
    }

    [Test] // user story 3
    public void BasketIsNotFull()
    {
        // arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket(inventory);
        basket.AddProduct(new Bagel("BGLO"));
        basket.AddProduct(new Bagel("BGLS"));
        basket.AddProduct(new Bagel("BGLS"));
        basket.AddProduct(new Bagel("BGLP"));

        // act
        bool isFull = basket.IsFull;

        // assert
        Assert.That(isFull, Is.False);
        Assert.DoesNotThrow(() => basket.AddProduct(new Bagel("BGLE"))); // adding another bagel should not throw an exception
    }

    [Test] // user story 4
    public void BasketCapacityCanBeSet()
    {
        // arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket(inventory);

        // act
        basket.BasketCapacity = 10;
        
        // assert
        Assert.That(basket.BasketCapacity, Is.EqualTo(10));
    }

    [Test] // user story 4
    public void BasketCapacityCannotBeSetToZeroOrNegative()
    {
        // arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket(inventory);

        // act & assert
        Assert.Throws<ArgumentException>(() => basket.BasketCapacity = 0);
        Assert.Throws<ArgumentException>(() => basket.BasketCapacity = -5);
    }

    [Test] // user story 5
    public void RemoveNonExistentProduct()
    {
        // arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket(inventory);
        basket.AddProduct(new Bagel("BGLS")); // adds a sesame bagel to basket

        // act & assert
        Assert.Throws<ArgumentException>(() => basket.RemoveProduct("BGLO")); // removing a non-present onion bagel is not allowed
    }

    [Test] // user story 6
    public void BasketTotal1()
    {
        // arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket(inventory);
        basket.AddProduct(new Bagel("BGLO"));
        basket.AddProduct(new Bagel("BGLP"));
        basket.AddProduct(new Bagel("BGLS"));

        // act
        decimal basketTotal = basket.BasketTotal;

        // assert
        Assert.That(basketTotal != 0);
        Assert.That(basketTotal, Is.EqualTo(1.37m)); // 0.49 + 0.39 + 0.49 = 1.37
    }

    [Test] // user story 6: make sure that it also adds the price for the bagel fillings to BasketTotal
    public void BasketTotal2()
    {
        // arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket(inventory);
        
        Filling cheese = new Filling("FILC");
        Filling bacon = new Filling("FILB");

        Bagel onionBagel = new Bagel("BGLO");
        onionBagel.AddFillings(new[] { cheese, bacon }, inventory); // add fillings to the onion bagel
        basket.AddProduct(onionBagel); // adds the onion bagel with fillings to the basket

        Bagel sesameBagel = new Bagel("BGLS");
        sesameBagel.AddFillings(new[] { cheese }, inventory); // add filling to the sesame bagel
        basket.AddProduct(sesameBagel); // adds the sesame bagel with filling to the basket

        // act
        decimal basketTotal = basket.BasketTotal;

        // assert
        Assert.That(basketTotal != 0);
        Assert.That(basketTotal, Is.EqualTo(1.34m)); // 0.49 (onion bagel) + 0.12 (bacon filling) + 0.12 (cheese filling) + 0.49 (sesame bagel) + 0.12 (cheese filling) = 1.34   
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
        Inventory inventory = new Inventory();
        Filling baconFilling = new Filling("FILB");
        Filling cheeseFilling = new Filling("FILC");
        Bagel onionBagel = new Bagel("BGLO");

        // act 
        onionBagel.AddFillings(new[] { baconFilling, cheeseFilling }, inventory);

        // assert
        Assert.That(onionBagel.Fillings.Count, Is.EqualTo(2));
        Assert.That(onionBagel.Fillings.Any(f => f.Id == "FILB"));
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

    [Test] // user story 10; check that a user cannot add a product that is not in inventory
    public void AddNonExistingProductToBasket()
    {
        // arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket(inventory);
        Bagel onionBagel = new Bagel("BGLO");
        Bagel fishBagel = new Bagel("BGLF");

        // act
        basket.AddProduct(onionBagel); // add the onion bagel to the basket
        // assert that onion bagel was added
        Assert.That(basket.basketItems.Count, Is.EqualTo(1));
        
        // act & assert
        Assert.Throws<ArgumentException>(() => basket.AddProduct(fishBagel)); // try do add the fishBagel to the basket (fish bagel is not in the inventory)
    }
    
    [Test] // user story 10; check that a user cannot add a filling that is not in inventory to a bagel 
    public void AddNonExistingFillingToBagel()
    {
        // arrange
        Inventory inventory = new Inventory();
        Bagel onionBagel = new Bagel("BGLO");
        Filling cheese = new Filling("FILC");
        Filling paprika = new Filling("FILP");

        // act & assert
        Assert.Throws<ArgumentException>(() => onionBagel.AddFillings(new[] {paprika, cheese}, inventory)); // try do add paprika filling to the onion bagel (paprika filling is not in the inventory)
    }
}