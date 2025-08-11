using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Bagel : IProduct
    {
        private string _variant;

        public Bagel(string variant)
        {
            _variant = variant;
        }
        public string Name { get; }

        public decimal Price { get; }

        public string Variant { get { return _variant; } set { _variant = value; } }

        public string Id { get; }
    }
}
