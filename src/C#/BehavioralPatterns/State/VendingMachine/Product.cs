using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class Product
    {
        public Product(string code, decimal price, int stock)
        {
            Code = code;
            Price = price;
            Stock = stock;
        }

        public string Code { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
