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

        private static readonly Dictionary<string, string> VariantNames = new Dictionary<string, string>()
        {
            {"BGLO", "Onion"},
            {"BGLP", "Plain"},
            {"BGLE", "Everything"},
            {"BGLS", "Sesame"}
        };

        private string _id;
        private List<Filling> _fillings = new List<Filling>();

        public Bagel(string id)
        {
            _id = id;
        }

        public string Name => "Bagel";

        public decimal Price
        {
            get
            {
                if (!VariantPrices.ContainsKey(_id))
                    throw new ArgumentException($"Invalid bagel id: {_id}");
                decimal price = VariantPrices[_id]; // get the spesific bagel´s price
                price += _fillings.Sum(f => f.Price);
                return price;
            }
        }

        public string Variant
        {
            get
            {
                if (!VariantNames.ContainsKey(_id))
                    throw new ArgumentException($"Invalid bagel id: {_id}");
                return VariantNames[_id];
            }
        }

        public string Id { get { return _id; } }

        public IReadOnlyList<Filling> Fillings => _fillings.AsReadOnly();
        public void AddFillings(IEnumerable<Filling> fillings, Inventory inventory)
        {
            foreach (var filling in fillings)
            {
                if (!inventory.IsInInventory(filling.Id))
                    throw new ArgumentException($"Filling {filling.Id} is not in inventory.");
                _fillings.Add(filling);
            }
        }
    }
}