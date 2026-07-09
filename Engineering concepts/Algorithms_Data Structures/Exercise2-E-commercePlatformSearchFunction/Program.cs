using System;

namespace EcommerceSearchExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product(101, "Laptop", "Electronics"),
                new Product(102, "Mobile", "Electronics"),
                new Product(103, "Shoes", "Fashion"),
                new Product(104, "Watch", "Accessories"),
                new Product(105, "Book", "Education")
            };

            Product? result1 = Search.LinearSearch(products, 104);

            if (result1 != null)
                Console.WriteLine($"Linear Search Found: {result1.ProductName}");
            else
                Console.WriteLine("Product not found using Linear Search");

            Product? result2 = Search.BinarySearch(products, 104);

            if (result2 != null)
                Console.WriteLine($"Binary Search Found: {result2.ProductName}");
            else
                Console.WriteLine("Product not found using Binary Search");
        }
    }
}