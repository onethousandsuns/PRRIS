using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Lab1___Discounts.Entity.Carts;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Entity.Discounts
{
    public class BaseDiscount : IDiscount
    {
        public string Name { get; }
        public decimal DiscountValue { get; }
        public virtual List<int> ApplyToProducts( ICartHandler cartHandler )
        {
            return new List<int>();
        }

        public BaseDiscount( decimal value, string name)
        {
            DiscountValue = value;
            Name = name;
        }

        public double GetPercentageDiscountValue( double price, decimal discountValue )
        {
            return price / 100 * (double) discountValue;
        }
    }
}