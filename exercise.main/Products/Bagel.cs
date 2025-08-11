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
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Variant { get; set; }

        public string Id { get; set; }
    }
}
