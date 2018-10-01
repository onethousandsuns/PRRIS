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

        public override List<int> ApplyToProducts( List<IProduct> products )
        {
            IProduct productA = cart.GetNotApplicatedByDiscountProductByProductKind( ProductKind.A );
            IProduct productC = cart.GetNotApplicatedByDiscountProductByProductKind( ProductKind.C );

            return new List<int>();
        }
    }
}