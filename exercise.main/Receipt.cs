using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private string _header = "    ~~~ Bob's Bagels ~~~";
        private string _thankuMessage = "        Thank you/nfor your order!";
        private string _separationSymbol = "----------------------------";
        private Basket _basket;
        // store order information in dictionary mapping from id to Iproduct.variant, name, amount ordered and price (amount ordered * price of one of this item)

        public Receipt(Basket basket)
        {
            _basket = basket;
            DateTime = System.DateTime.Now;
        }

        // method to loop through the items ordered (basket.basketItems) and store the information in the dictionary 
        

        // total price is retrieved from basket.BasketTotal

        public DateTime DateTime { get; set; }

        public void Print()
        {
            Console.WriteLine(_header);
            Console.WriteLine();
            Console.WriteLine($"    {DateTime}");
            Console.WriteLine();
            Console.WriteLine(_separationSymbol);
            Console.WriteLine();

            // print: $"{Iproduct.name} {iproduct.variant} tab {number of this item ordered} tab {price: base product price * amount ordered}"
        }
    }
}
