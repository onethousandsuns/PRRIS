using System.Collections.Generic;
using Lab1___Discounts.Entity.Carts;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Service.Calculators
{
    public class CartPriceCalculator : ICalculator
    {
        private readonly ICartHandler _cartHandler;

        public CartPriceCalculator( ICartHandler cartHandler )
        {
            _cartHandler = cartHandler;
        }

        public double Calculate()
        {
            double result = 0;

            foreach ( KeyValuePair<int, IProduct> product in ( ( _cartHandler.Products ) ) )
            {
                result += product.Value.Price;
            }

            return result;
        }
    }
}