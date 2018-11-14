using System.Collections.Generic;
using Lab1___Discounts.Entity.Carts;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Entity.Discounts
{
    public class Discount_2 : BaseDiscount
    {
        public Discount_2( decimal value, string name ) 
            : base( value, name )
        {
        }

        public override List<int> ApplyToProducts( ICartHandler cartHandler )
        {
            var productD = cartHandler.GetNotApplicatedByDiscountProductByProductKind( ProductKind.D );
            var productE = cartHandler.GetNotApplicatedByDiscountProductByProductKind( ProductKind.E );

            if (productD != null && productE != null)
            {
                productD.Value.Value.Price -= GetPercentageDiscountValue(productD.Value.Value.Price, DiscountValue);
                cartHandler.MarkProductAsAppliedByDiscount( productD.Value.Value );

                productE.Value.Value.Price -= GetPercentageDiscountValue(productE.Value.Value.Price, DiscountValue);
                cartHandler.MarkProductAsAppliedByDiscount( productE.Value.Value );

                return new List<int>
                {
                    productD.Value.Key,
                    productE.Value.Key
                };
            }

            return new List<int>();
        }
    }
}