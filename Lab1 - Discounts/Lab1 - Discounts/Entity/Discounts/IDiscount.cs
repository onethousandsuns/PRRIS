using System.Collections.Generic;
using Lab1___Discounts.Entity.Carts;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Entity.Discounts
{
    public interface IDiscount
    {
        string Name { get; }
        decimal Value { get; }

        List<int> ApplyToProducts( List<IProduct> products );
    }
}