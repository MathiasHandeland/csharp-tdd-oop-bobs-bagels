using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exercise.main
{
    public class Basket
    {
        private List<IProduct> _basketItems = new List<IProduct>();
        private int _basketCapacity = 5; // default capacity of the basket
        private Inventory _inventory = new Inventory();

        public Basket(Inventory inventory)
        {
            _inventory = inventory;
        }

        public void AddProduct(IProduct product)
        {
            if (IsFull)
                throw new InvalidOperationException("Basket is full. Cannot add more products.");
            if (!_inventory.IsInInventory(product.Id)) // check if the product the customer wants to add i present in the inventory
                throw new ArgumentException($"Product with SKU {product.Id} is not available in inventory.");
            _basketItems.Add(product); // if it is, add it to the basket
        }

        public void RemoveProduct(string productId)
        {
            var productToRemove = _basketItems.FirstOrDefault(p => p.Id == productId);
            if (productToRemove != null)
            {
                _basketItems.Remove(productToRemove);
            }
            else
            {
                throw new ArgumentException("The item with this Id is not present in your basket. Could not be removed");
            }
        }

        public List<IProduct> basketItems { get { return _basketItems; } }

        public bool IsFull { get { return _basketItems.Count >= _basketCapacity; } }

        public int BasketCapacity
        {
            get { return _basketCapacity; }
            set
            {
                if (value > 0)
                {
                    _basketCapacity = value;
                }
                else
                {
                    throw new ArgumentException("Basket capacity must be greater than zero.");
                }
            }

        }

        /// <summary>
        /// Groups all bagels by SKU.
        /// For each bagel group, apply the discount for every 6 bagels with same SKU, and adds the base bagel price for any leftovers.
        /// Add the price of all other products as normal to BasketTotal
        /// </summary>
        public decimal BasketTotal
        {
            get
            {
                decimal total = 0m;
                total += GetBagelDiscountTotal();
                total += GetNonBagelTotal();
                return total;
            }
        }
        public decimal GetBagelDiscountTotal()
        {
           
            decimal total = 0m;

            // Group bagels by SKU
            var bagelGroups = _basketItems
                .Where(p => p.Name is "Bagel")
                .Cast<Bagel>() // Cast to Bagel to access specific properties
                .GroupBy(b => b.Id);

            foreach (var group in bagelGroups) // loop through each group of bagels
            {
                int count = group.Count(); // count how many bagels of the same SKU are in the group
                decimal basePrice = Bagel.GetBasePrice(group.Key); // get the base price of the bagel

                // 12-for-£3.99
                int setsOf12 = count / 12;
                int remainderAfter12 = count % 12;

                // 6-for-£2.49
                int setsOf6 = remainderAfter12 / 6;
                int remainder = remainderAfter12 % 6;

                total += setsOf12 * 3.99m; // add the price for every 12 bagels
                total += setsOf6 * 2.49m; // add the price for every 6 bagels
                total += remainder * basePrice; // add the price for any leftover bagels that do not fit into a 6 or 12 set

                // Sums the price of all fillings for all bagels in each group and adds it to the total.
                total += group.SelectMany(b => b.Fillings).Sum(f => f.Price);
            }
            return total; 
        }

        // Add all non-bagel products (coffee, fillings)
        public decimal GetNonBagelTotal()
        {
            return _basketItems
                .Where(p => p.Name is not "Bagel")
                .Sum(p => p.Price);
        }
    }
}