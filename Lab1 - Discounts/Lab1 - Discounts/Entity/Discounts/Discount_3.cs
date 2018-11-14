using System.Collections.Generic;
using Lab1___Discounts.Entity.Carts;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Entity.Discounts
{
    public class Discount_3 : BaseDiscount
    {
        public Discount_3( decimal value, string name ) 
            : base( value, name )
        {
        }

        public override List<int> ApplyToProducts( ICartHandler cartHandler )
        {
            var productE = cartHandler.GetNotApplicatedByDiscountProductByProductKind(ProductKind.E);
            var productF = cartHandler.GetNotApplicatedByDiscountProductByProductKind(ProductKind.F);
            var productG = cartHandler.GetNotApplicatedByDiscountProductByProductKind(ProductKind.G);

            if (productF != null && productE != null && productG != null)
            {
                productF.Value.Value.Price -= GetPercentageDiscountValue(productF.Value.Value.Price, DiscountValue);
                cartHandler.MarkProductAsAppliedByDiscount( productF.Value.Value );

                productE.Value.Value.Price -= GetPercentageDiscountValue(productE.Value.Value.Price, DiscountValue);
                cartHandler.MarkProductAsAppliedByDiscount( productE.Value.Value );

                productG.Value.Value.Price -= GetPercentageDiscountValue(productG.Value.Value.Price, DiscountValue);
                cartHandler.MarkProductAsAppliedByDiscount(productG.Value.Value);

                return new List<int>
                {
                    productF.Value.Key,
                    productG.Value.Key,
                    productE.Value.Key
                };
            }

            return new List<int>();
        }
    }
}