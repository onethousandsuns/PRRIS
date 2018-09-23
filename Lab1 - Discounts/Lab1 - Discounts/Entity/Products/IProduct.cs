using Lab1___Discounts.Entity.Discounts;

namespace Lab1___Discounts.Entity.Products
{
    public interface IProduct
    {
        string ProductName { get; }

        double Price { get; }

        IDiscount Discount { get; }
    }
}