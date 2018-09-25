using System.Collections.Generic;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Entity.Discounts
{
    public class Discount_1 : BaseDiscount
    {
        public Discount_1( decimal value, string name ) 
            : base( value, name )
        {
        }

        public override List<int> Apply( List<IProduct> products )
        {
            base.Apply( products );
            
            return new List<int>();
        }
    }
}