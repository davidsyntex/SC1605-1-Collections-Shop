using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Item
    {
        public string Name { get; }
        public double Price { get; }
        public string Description { get; }

        public Item(string name, double price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
