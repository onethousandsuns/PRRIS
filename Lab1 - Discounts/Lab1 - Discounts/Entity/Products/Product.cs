using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1___Discounts.Entity.Discounts;

namespace Lab1___Discounts.Entity.Products
{
    class Product : IProduct
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public IDiscount Discount { get; set; }
    }
}
