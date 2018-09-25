using System;
using System.Collections.Generic;
using System.Linq;
using Lab1___Discounts.Entity.Discounts;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Service.Calculators
{
    public class CartCalculator : ICalculator
    {
        private readonly List<IDiscount> _discounts;
        private readonly Dictionary<int, IProduct> _products;
        private readonly List<int> _notApplicatedProducts;

        public CartCalculator( List<IProduct> products, List<IDiscount> discounts )
        {
            _discounts = discounts;
            int index = 0;
            _products = products.ToDictionary( item => index++ );
            _notApplicatedProducts = _products.Keys.ToList();
        }

        public double Calculate()
        {
            double result = 0;

            foreach ( KeyValuePair<int, IProduct> product in _products )
            {
                result += product.Value.Price;
            }

            return result;
        }

        private void ApplyDiscounts()
        {
            foreach ( IDiscount discount in _discounts )
            {
                List<int> applicatedProductsIds = discount.Apply( _products.Values.ToList() );
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