using System;
using System.Collections.Generic;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Entity.Carts
{
    public interface ICartHandler
    {
        Dictionary<int, IProduct> Products { get; }
        void ApplyDiscounts();
        KeyValuePair<int, IProduct>? GetNotApplicatedByDiscountProductByProductKind( ProductKind productKind );
        Dictionary<int, IProduct> GetSpecificAmountOfProducts(int amount, List<ProductKind> excludedKinds = null);
        void MarkProductAsAppliedByDiscount(IProduct product);
    }
}
