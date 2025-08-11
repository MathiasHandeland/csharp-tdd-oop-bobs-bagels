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
        public void AddProduct(IProduct product)
        {
            _basketItems.Add(product);
        }

        public List<IProduct> basketItems { get { return _basketItems; }
        }
    }
}
