using Lab1___Discounts.Entity.Carts;
using Lab1___Discounts.Entity.Products;

namespace Lab1___Discounts.Service.Calculators
{
    public class CartCalculator : ICalculator
    {
        private readonly ICart _cart;

        public CartCalculator( ICart cart )
        {
            _cart = cart;
        }

        public double Calculate()
        {
            double result = 0;

            foreach ( IProduct product in ( ( _cart.Products ) ) )
            {
                result += product.Price;
            }

            return result;
        }
    }
}