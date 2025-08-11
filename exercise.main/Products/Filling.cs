using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Filling : IProduct
    {

        private string _id;

        public Filling(string id)
        {
            _id = id;
        }
        public string Name => "Filling";

        public decimal Price => 0.12m; // the price is the same for every variant of filling

        public string Variant { get; }

        public string Id => throw new NotImplementedException();
    }
}
