using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<IProduct> _basketItems = new List<IProduct>();
        private int _basketCapacity = 5;

        private Inventory _inventory = new Inventory();

        public Basket(Inventory inventory)
        {
            _inventory = inventory;
        }

        public void AddProduct(IProduct product)
        {
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

        public decimal BasketTotal { get { return _basketItems.Sum(product => product.Price); } }

    }
}


