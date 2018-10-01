using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Entity.Carts
{
    public interface ICart
    {
        List<IProduct> Products { get; }
        IProduct GetNotApplicatedByDiscountProductByProductKind( ProductKind productKind );
    }
}
