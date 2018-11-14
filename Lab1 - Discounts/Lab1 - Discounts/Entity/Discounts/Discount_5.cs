using System.Collections.Generic;
using Lab1___Discounts.Entity.Carts;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Entity.Discounts
{
    public class Discount_5 : BaseDiscount
    {
        public Discount_5( decimal value, string name ) 
            : base( value, name )
        {
        }

        public override List<int> ApplyToProducts( ICartHandler cartHandler )
        {
            var products = cartHandler.GetSpecificAmountOfProducts(3, new List<ProductKind>
            {
                ProductKind.A,
                ProductKind.C
            });

            if (products != null)
            {
                var result = new List<int>();
                foreach (var product in products)
                {
                    product.Value.Price -= GetPercentageDiscountValue(product.Value.Price, DiscountValue);
                    cartHandler.MarkProductAsAppliedByDiscount(product.Value);
                    result.Add(product.Key);
                }

                return result;
            }

            return new List<int>();
        }
    }
}