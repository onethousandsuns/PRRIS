using System.Collections.Generic;
using System.Linq;
using Lab1___Discounts.Entity.Discounts;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Entity.Carts
{
    public class ProductCartHandlerHandler : ICartHandler
    {
        public Dictionary<int, IProduct> Products
        {
            get { return _products; }
        }

        private readonly List<IDiscount> _discounts;
        private readonly Dictionary<int, IProduct> _products;
        private readonly List<int> _notApplicatedProducts;

        public ProductCartHandlerHandler( List<IProduct> products, List<IDiscount> discounts )
        {
            _discounts = discounts;
            int index = 0;
            _products = products.ToDictionary(item => index++);
            _notApplicatedProducts = _products.Keys.ToList();
        }
        public void ApplyDiscounts()
        {
            foreach (IDiscount discount in _discounts)
            {
                while (true)
                {
                    List<int> applicatedProductsIds = discount.ApplyToProducts(this);
                    if (applicatedProductsIds.Count == 0)
                    {
                        return;
                    }

                    foreach (int applicatedProductId in applicatedProductsIds)
                    {
                        _notApplicatedProducts.RemoveAll(x => x == applicatedProductId);
                    }
                }
            }
        }

        #region ProductCartHelpers

        public KeyValuePair<int, IProduct>? GetNotApplicatedByDiscountProductByProductKind(ProductKind productKind)
        {
            foreach (KeyValuePair<int, IProduct> product in _products)
            {
                if (!product.Value.IsDiscountApplied && _notApplicatedProducts.Contains(product.Key))
                {
                    return product;
                }
            }

            return null;
        }

        public Dictionary<int, IProduct> GetSpecificAmountOfProducts(int amount, List<ProductKind> excludedKinds = null)
        {
            var unapplicatedProducts = GetUnapplicatedByDiscountProducts();
            if (unapplicatedProducts.Count < amount)
            {
                return null;
            }

            if (excludedKinds != null)
            {
                foreach (var product in unapplicatedProducts)
                {
                    if (excludedKinds.Contains(product.Value.ProductKind))
                    {
                        unapplicatedProducts.Remove(product.Key);
                    }
                }
            }

            if (unapplicatedProducts.Count < amount)
            {
                return null;
            }

            return unapplicatedProducts.Take(amount) as Dictionary<int, IProduct>;
        }

        private Dictionary<int, IProduct> GetUnapplicatedByDiscountProducts()
        {
            var unapplicatedProducts = new Dictionary<int, IProduct>();
            foreach (var product in _products)
            {
                if (product.Value.IsDiscountApplied)
                {
                    continue;
                }
                unapplicatedProducts.Add(product.Key, product.Value);
            }

            return unapplicatedProducts;
        }

        public void MarkProductAsAppliedByDiscount(IProduct product)
        {
            product.IsDiscountApplied = true;
        }


        #endregion

    }
}