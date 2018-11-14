using Lab1___Discounts.Entity.Discounts;

namespace Lab1___Discounts.Entity.Products
{
    public class Product : IProduct
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public ProductKind ProductKind { get; set; }
        public bool IsDiscountApplied { get; set; }
    }
}
