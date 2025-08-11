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
        private string _id;

        public Bagel(string variant)
        {
            _variant = variant;
        }
        public Bagel(string variant, string id)
        {
            _variant = variant;
            _id = id;
        }
        public string Name { get; }

        public decimal Price { get; }

        public string Variant { get { return _variant; } }

        public string Id { get { return _id; } }
    }
}
