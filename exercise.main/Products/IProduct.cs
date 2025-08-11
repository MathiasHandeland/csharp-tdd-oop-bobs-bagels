using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public interface IProduct
    {
        string Name { get; }
        decimal Price { get; }
        string Variant { get; set; }
        string Id { get; }
    }
}
