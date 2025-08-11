using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        private HashSet<string> _inventory = new HashSet<string>()
        {
            "BGLO", "BGLP", "BGLE", "BGLS", // bagel variant SKUs
            "FILB", "FILE", "FILC", "FILX", "FILS", "FILH", // filling variant SKUs
            "COFB", "COFW", "COFC", "COFL" // coffee variant SKUs
        };

        public bool IsInInventory(string productId)
        {
            return _inventory.Contains(productId);
        }
    }
}
