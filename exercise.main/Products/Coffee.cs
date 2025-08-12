using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Coffee : IProduct
    {
       
        private static readonly Dictionary<string, decimal> VariantPrices = new Dictionary<string, decimal>()
        {
            {"COFB", 0.99m}, // Black coffee
            {"COFW", 1.19m}, // White coffee
            {"COFC", 1.29m}, // Capuccino
            {"COFL", 1.29m}  // Latte
        };

        private static readonly Dictionary<string, string> VariantNames = new Dictionary<string, string>()
        {
            {"COFB", "Black"},
            {"COFW", "White"},
            {"COFC", "Capuccino"},
            {"COFL", "Latte"}
        };

        private string _id;

        public Coffee(string id)
        {
            _id = id;
        }
        public string Name => "Coffee";

        public decimal Price
        {
            get
            {
                if (!VariantPrices.ContainsKey(_id))
                    throw new ArgumentException($"Invalid coffee id: {_id}");
                decimal price = VariantPrices[_id]; // get the spesific coffee´s price
                return price;
            }
        }

        public string Variant
        {
            get
            {
                if (!VariantNames.ContainsKey(_id))
                    throw new ArgumentException($"Invalid coffee id: {_id}");
                return VariantNames[_id];
            }
        }

        public string Id { get { return _id; } }
    }
}