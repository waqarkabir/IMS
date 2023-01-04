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
                Console.WriteLine(products[i]);
            }

            Console.WriteLine("Enter any key to exit");

        }

        public static void Search(Product[] products, int productIndex)
        {
            Console.WriteLine("Enter a product to search");
            string searchString = Console.ReadLine();

            if (string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString))
            {
                Console.WriteLine("Search string cannot be null!");
            }

            bool stringFound = false;

            for (int i = 0; i < productIndex; i++)
            {
                if (products[i].Name.Contains(searchString))
                {
                    Console.WriteLine(products[i]);
                    stringFound = true;
                    break;
                }
            }

            if (!stringFound)
            {
                Console.WriteLine($"No product with name '{searchString}' is available, try again ");
            }
        }

        public static Product[] Update(Product[] products)
        {

            Console.WriteLine("Enter a product id to edit");
            int searchIndex = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter New Product Name");

            string name = Console.ReadLine();

            Console.WriteLine("Enter New Product Description");

            string description = Console.ReadLine();
            products[searchIndex - 1].Name = name;

            products[searchIndex - 1].Description = description;

            Console.WriteLine("Product Updated");

            return products;
        }
    }
}
