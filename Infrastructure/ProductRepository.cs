using Entities;
using System;

namespace Infrastructure
{
    public static class ProductRepository
    {
        public static Product[] Create(Product[] products, int productIndex, int categoryId)
        {
            Console.WriteLine("Enter Product Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Product Description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Product Category Id from Category List");

            Product product = new Product(name,description,categoryId);
            product.Id = productIndex+1;
            products[productIndex] = product;
            Console.WriteLine(product);

            return products;
        }

        public static void List(Product[] products, int productIndex)
        {
            if (productIndex == 0)
            {
                Console.WriteLine("There are no products entered yet!");
                Console.WriteLine("Enter any key to exit");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Product List");

            for (int i = 0; i < productIndex; i++)
            {
                Console.WriteLine($"Product Id is {i + 1}, {products[i]}");
            }

        }
    }
}
