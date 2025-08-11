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

        public void AddProduct(IProduct product)
        {
            _basketItems.Add(product);
        }

        public void RemoveProduct(string productId)
        {
            var productToRemove = _basketItems.FirstOrDefault(p => p.Id == productId);
            if (productToRemove != null)
            {
                _basketItems.Remove(productToRemove);
            }
        }

        public List<IProduct> basketItems { get { return _basketItems; } }

        public bool IsFull { get { return _basketItems.Count >= _basketCapacity; } }

    }    
}


