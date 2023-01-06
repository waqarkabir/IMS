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
            product.Id = productIndex;
            products[productIndex] = product;
            Console.WriteLine($"Product Id: {productIndex+1} , {product}");

            return products;
        }

        public static bool List(Product[] products, int productIndex)
        {
            if (productIndex == 0)
            {
                Console.WriteLine("There are no products entered yet!");
                Console.WriteLine("Enter any key to exit");
                Console.ReadKey();
                return false;
            }
            Console.WriteLine("Product List");

            for (int i = 0; i < productIndex; i++)
            {
                Console.WriteLine("Product Id:"+ (i + 1) + " , " + products[i]);
            }

            return true;
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

        public static Product[] Delete(Product[] products, int productIndex, int productId)
        {

            for (int i = Convert.ToInt32(productId); i < productIndex; i++)
            {
                products[i - 1] = products[i];
            }


            Product[] newArray = new Product[100];
            Array.Copy(products, newArray, productIndex - 1);

            Console.WriteLine("Product Deleted");
            return newArray;
        }
    }
}
