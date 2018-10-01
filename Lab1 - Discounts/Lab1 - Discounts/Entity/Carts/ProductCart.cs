using System.Collections.Generic;
using System.Linq;
using Lab1___Discounts.Entity.Discounts;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Entity.Carts
{
    public class ProductCart : ICart
    {
        public List<IProduct> Products { get; set; }

        private readonly List<IDiscount> _discounts;
        private readonly Dictionary<int, IProduct> _products;
        private readonly List<int> _notApplicatedProducts;

        public ProductCart( List<IProduct> products, List<IDiscount> discounts )
        {
            _discounts = discounts;
            int index = 0;
            _products = products.ToDictionary(item => index++);
            _notApplicatedProducts = _products.Keys.ToList();
        }

        public IProduct GetNotApplicatedByDiscountProductByProductKind( ProductKind productKind )
        {
            foreach ( KeyValuePair<int, IProduct> product in _products )
            {
                if ( !product.Value.IsDiscountApplied && _notApplicatedProducts.Contains( product.Key ) )
                {
                    return product.Value;
                }
            }

            return null;
        }

        private void ApplyDiscounts()
        {
            foreach ( IDiscount discount in _discounts )
            {
                List<int> applicatedProductsIds = discount.ApplyToCart( this );
                foreach (int applicatedProductId in applicatedProductsIds)
                {
                    _notApplicatedProducts.RemoveAll( x => x == applicatedProductId );
                }
            }
        }

        private void MarkProductAsAppliedByDiscount( Product product )
        {
            product.IsDiscountApplied = true;
        }
    }
}