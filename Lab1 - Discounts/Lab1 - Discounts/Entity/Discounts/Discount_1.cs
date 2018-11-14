using System.Collections.Generic;
using Lab1___Discounts.Entity.Carts;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Entity.Discounts
{
    public class Discount_1 : BaseDiscount
    {
        public Discount_1( decimal value, string name ) 
            : base( value, name )
        {
        }

        public override List<int> ApplyToProducts( ICartHandler cartHandler )
        {
            var productA = cartHandler.GetNotApplicatedByDiscountProductByProductKind( ProductKind.A );
            var productB = cartHandler.GetNotApplicatedByDiscountProductByProductKind( ProductKind.B );

            if (productA != null && productB != null)
            {
                productA.Value.Value.Price -= GetPercentageDiscountValue(productA.Value.Value.Price, DiscountValue);
                cartHandler.MarkProductAsAppliedByDiscount( productA.Value.Value );

                productB.Value.Value.Price -= GetPercentageDiscountValue(productB.Value.Value.Price, DiscountValue);
                cartHandler.MarkProductAsAppliedByDiscount( productB.Value.Value );

                return new List<int>
                {
                    productA.Value.Key,
                    productB.Value.Key
                };
            }

            return new List<int>();
        }
    }
}