using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public abstract class Product
    {
        protected Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
