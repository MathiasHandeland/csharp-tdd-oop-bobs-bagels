using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Filling : IProduct
    {
        private static readonly Dictionary<string, string> VariantNames = new Dictionary<string, string>()
        {
            {"FILB", "Bacon"},
            {"FILE", "Egg"},
            {"FILC", "Cheese"},
            {"FILX", "Creamy Cheese"},
            {"FILS", "Smoked Salmon"},
            {"FILH", "Ham"}
        };

        private string _id;

        public Filling(string id)
        {
            _id = id;
        }
        public string Name => "Filling";

        public decimal Price => 0.12m; // price is the same for every filling variant

        public string Variant
        {
            get
            {
                if (!VariantNames.ContainsKey(_id))
                    throw new ArgumentException($"Invalid filling id: {_id}");
                return VariantNames[_id];
            }
        }

        public string Id { get { return  _id; } } 
    }
}
