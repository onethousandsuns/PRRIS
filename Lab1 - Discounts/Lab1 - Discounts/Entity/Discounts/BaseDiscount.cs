using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Lab1___Discounts.Entity.Carts;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Entity.Discounts
{
    public class BaseDiscount : IDiscount
    {
        public string Name { get; }
        public decimal Value { get; }
        public virtual List<int> ApplyToProducts( List<IProduct> products )
        {
            return new List<int>();
        }

        public BaseDiscount( decimal value, string name)
        {
            Value = value;
            Name = name;
        }
    }
}