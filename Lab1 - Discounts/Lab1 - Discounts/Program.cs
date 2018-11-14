using System;
using System.Collections.Generic;
using Lab1___Discounts.Entity.Carts;
using Lab1___Discounts.Entity.Discounts;
using Lab1___Discounts.Entity.Products;
using Lab1___Discounts.Service.Calculators;

namespace Lab1___Discounts
{
    // Задание - https://docs.google.com/document/d/1PDOOmzVVgG_PebOZLxDxllO-UmRHVoyqpm-LUlbcv5o/edit
    class Program
    {
        static void Main( string[] args )
        {
            List<IProduct> products = GetInitializedProducts();
            List<IDiscount> discounts = GetInitializedDiscounts();

            ProductCartHandlerHandler productCartHandlerHandler = new ProductCartHandlerHandler( products, discounts );
            productCartHandlerHandler.ApplyDiscounts();

            CartPriceCalculator cartPriceCalculator = new CartPriceCalculator( productCartHandlerHandler );
            Console.WriteLine(cartPriceCalculator.Calculate());
            Console.ReadLine();
        }

        private static List<IProduct> GetInitializedProducts()
        {
            List<IProduct> products = new List<IProduct>
            {
                new Product{ Price = 100, ProductName = "ProductA" },
                new Product{ Price = 100, ProductName = "ProductB" },
                new Product{ Price = 100, ProductName = "ProductC" },
                new Product{ Price = 100, ProductName = "ProductD" },
                new Product{ Price = 100, ProductName = "ProductE" },
                new Product{ Price = 100, ProductName = "ProductF" },
                new Product{ Price = 100, ProductName = "ProductG" },
                new Product{ Price = 100, ProductName = "ProductH" },
                new Product{ Price = 100, ProductName = "ProductI" },
                new Product{ Price = 100, ProductName = "ProductJ" },
                new Product{ Price = 100, ProductName = "ProductK" },
                new Product{ Price = 100, ProductName = "ProductL" },
                new Product{ Price = 100, ProductName = "ProductM" }
            };

            return products;
        }

        private static List<IDiscount> GetInitializedDiscounts()
        {
            List<IDiscount> discounts = new List<IDiscount>
            {
                new Discount_1( 10, "Discount_1" ),
                new Discount_2( 5, "Discount_2" ),
                new Discount_3( 5, "Discount_3" ),
                new Discount_4( 5, "Discount_4" ),
                new Discount_5( 5, "Discount_5" ),
                new Discount_6( 10, "Discount_6" ),
                new Discount_7( 20, "Discount_7" )
            };

            return discounts;
        }
    }
}
