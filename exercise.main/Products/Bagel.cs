using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Bagel : IProduct
    {

        private static readonly Dictionary<string, decimal> VariantPrices = new Dictionary<string, decimal>()
        {
            {"BGLO", 0.49m}, // Onion
            {"BGLP", 0.39m}, // Plain
            {"BGLE", 0.49m}, // Everything
            {"BGLS", 0.49m}  // Sesame
        };

        private string _id;

        public Bagel(string id)
        {
            _id = id;
        }

        // TODO: extra constructor for bagel where you can choose filling

        public string Name => "Bagel";

        public decimal Price
        {
            get
            {
                if (!VariantPrices.ContainsKey(_id))
                    throw new ArgumentException($"Invalid bagel id: {_id}");
                return VariantPrices[_id];
            }
        }

        public string Variant { get; }

        public string Id { get { return _id; } }


    }
}
