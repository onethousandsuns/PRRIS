using System.Collections.Generic;
using Lab1___Discounts.Entity.Carts;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Entity.Discounts
{
    public class Discount_4 : BaseDiscount
    {
        public Discount_4( decimal value, string name ) 
            : base( value, name )
        {
        }

        public override List<int> ApplyToProducts( ICartHandler cartHandler )
        {
            var productA = cartHandler.GetNotApplicatedByDiscountProductByProductKind(ProductKind.A);

            var productKLM = (cartHandler.GetNotApplicatedByDiscountProductByProductKind(ProductKind.K) 
                                ?? cartHandler.GetNotApplicatedByDiscountProductByProductKind(ProductKind.L)) 
                                ?? cartHandler.GetNotApplicatedByDiscountProductByProductKind(ProductKind.M);


            if (productA != null && productKLM != null )
            {
                productKLM.Value.Value.Price -= GetPercentageDiscountValue(productKLM.Value.Value.Price, DiscountValue);
                cartHandler.MarkProductAsAppliedByDiscount(productKLM.Value.Value );

                productA.Value.Value.Price -= GetPercentageDiscountValue(productA.Value.Value.Price, DiscountValue);
                cartHandler.MarkProductAsAppliedByDiscount( productA.Value.Value );


                return new List<int>
                {
                    productKLM.Value.Key,
                    productA.Value.Key
                };
            }

            return new List<int>();
        }
    }
}