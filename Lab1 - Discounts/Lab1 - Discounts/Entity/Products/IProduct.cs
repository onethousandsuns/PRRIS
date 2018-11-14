using Lab1___Discounts.Entity.Discounts;

namespace Lab1___Discounts.Entity.Products
{
    public interface IProduct
    {
        string ProductName { get; set; }
        double Price { get; set; }
        ProductKind ProductKind { get; set; }
        bool IsDiscountApplied { get; set; }
    }
}