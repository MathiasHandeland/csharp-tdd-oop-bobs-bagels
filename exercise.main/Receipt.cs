using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private string _header = "    ~~~ Bob's Bagels ~~~";
        private string _thankuMessage1 = "        Thank you";
        private string _thankuMessage2 = "      for your order!";
        private string _separationSymbol = "----------------------------";
        private Basket _basket;
        
        // Dictionary to store the ordered items with associated details
        private Dictionary<string, (string Name, string Variant, int Quantity, decimal Subtotal)> orderDict =
            new Dictionary<string, (string Name, string Variant, int Quantity, decimal Subtotal)>();

        public Receipt(Basket basket)
        {
            _basket = basket;
            DateTime = DateTime.Now;
        }

        // method to loop through the items ordered (basket.basketItems) and store the information in the dictionary 
        private void PopulateOrderDictionary()
        {
            orderDict.Clear();
            foreach (IProduct product in _basket.basketItems)
            {
                string key = product.Id;
                if (orderDict.ContainsKey(key))
                {
                    // If the item already exists in the dictionary, increment the quantity and update subtotal
                    var existingItem = orderDict[key];
                    existingItem.Quantity++;
                    existingItem.Subtotal += product.Price;
                    orderDict[key] = existingItem;
                }
                else
                {
                    // If it's a new item, add it to the dictionary, base count 1
                    orderDict[key] = (product.Name, product.Variant, 1, product.Price);
                }
            }    
        }

        public DateTime DateTime { get; set; }

        public void Print()
        {
            PopulateOrderDictionary();

            Console.WriteLine(_header);
            Console.WriteLine($"\n    {DateTime.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.WriteLine($"\n{_separationSymbol}\n");

            foreach (var item in orderDict)
            {
                var productDetails = item.Value;
                string itemName = $"{productDetails.Variant} {productDetails.Name}".Trim();
                string qty = productDetails.Quantity.ToString();
                string subtotal = productDetails.Subtotal.ToString("£0.00", CultureInfo.InvariantCulture);

                Console.WriteLine("{0,-16} {1,3} {2,7}", itemName, qty, subtotal);
            }

            Console.WriteLine($"\n{_separationSymbol}\n");
            string totalLabel = "Total";
            string totalValue = _basket.BasketTotal.ToString("£0.00", CultureInfo.InvariantCulture).PadLeft(28 - totalLabel.Length);
            Console.WriteLine(totalLabel + totalValue);
            Console.WriteLine($"\n{_thankuMessage1}");
            Console.WriteLine($"{_thankuMessage2}");
        }
    }
}