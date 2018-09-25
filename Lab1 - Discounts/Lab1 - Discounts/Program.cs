using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            List<IProduct> products = new List<IProduct>();
            List<IDiscount> discounts = new List<IDiscount>()
            {
                new Discount_1( 50, "Discount_1" )
            };

            ICalculator cartCalculator = new CartCalculator( products, discounts );

            Console.WriteLine( String.Format( "Products: {0} /n", products.ToString() ) );
            Console.WriteLine( String.Format( "Discounts: {0} /n", discounts ) );
            Console.WriteLine( cartCalculator.Calculate().ToString() );
            Console.ReadLine();
        }
    }
}
