using Entities;
using Infrastructure;
using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Category[] categories = new Category[10];
            Product[] products = new Product[100];
            int categoryIndex = 0;
            int productIndex = 0;
            bool mainMenuTerminator = false;
            string input;

            do
            {
                Console.WriteLine("___________________________________");
                Console.WriteLine("IMS Main Menu");
                Console.WriteLine("Select a menu");
                Console.WriteLine("1) Category Management");
                Console.WriteLine("2) Product Management");
                Console.WriteLine("___________________________________");

                input = Console.ReadLine();
                bool subMenuTerminator = false;
                if (input == "1")
                {
                    do
                    {
                        Console.Clear();

                        Console.WriteLine("___________________________________");
                        Console.WriteLine("Category Management Menu");
                        Console.WriteLine("Select a menu");
                        Console.WriteLine("1) New Category");
                        Console.WriteLine("2) Display Category List");
                        Console.WriteLine("3) Search Category");
                        Console.WriteLine("4) Update Category");
                        Console.WriteLine("5) Delete Category");
                        Console.WriteLine("6) Main Menu");
                        Console.WriteLine("7) Terminate Program");
                        Console.WriteLine("___________________________________");

                        input = Console.ReadLine();

                        switch (input)
                        {
                            case "1":
                                Console.Clear();

                                #region Create Category

                                Console.Clear();
                                try
                                {
                                    categories = CategoryRepository.Create(categories, categoryIndex);
                                }
                                catch (ArgumentNullException)
                                {
                                    Console.WriteLine("Name and Description is required!");
                                    Console.WriteLine("Enter any key for main menu");
                                    Console.ReadKey();
                                    break;
                                }
                                categoryIndex = categoryIndex + 1;

                                Console.WriteLine("Press any key for main menu");
                                Console.ReadKey();
                                #endregion

                                break;
                            case "2":
                                Console.Clear();
                                #region Category List

                                CategoryRepository.List(categories, categoryIndex);

                                Console.ReadKey();

                                #endregion
                                break;
                            case "3":
                                Console.Clear();
                                #region Search Category
                                CategoryRepository.SearchByName(categories, categoryIndex);
                                Console.ReadKey();
                                #endregion
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                subMenuTerminator = true;
                                break;
                        }
                    } while (!subMenuTerminator);
                }
                else
                {
                    do
                    {
                        Console.Clear();

                        Console.WriteLine("___________________________________");
                        Console.WriteLine("Product Management Menu");
                        Console.WriteLine("Select a menu");
                        Console.WriteLine("1) New Product");
                        Console.WriteLine("2) Display Product List");
                        Console.WriteLine("3) Search Product");
                        Console.WriteLine("4) Update Product");
                        Console.WriteLine("5) Delete Product");
                        Console.WriteLine("6) Main Menu");
                        Console.WriteLine("7) Terminate Program");
                        Console.WriteLine("___________________________________");

                        input = Console.ReadLine();

                        switch (input)
                        {
                            case "1":
                                Console.Clear();

                                #region Create Product
                                bool categoryEmpty = CategoryRepository.List(categories, categoryIndex);
                                bool categoryFound = false; 
                                if (!categoryEmpty)
                                {
                                    Console.WriteLine("Empty Category List");
                                    break;
                                }

                                Console.WriteLine("Enter a category of Product");

                                int categoryId = 0;
                                int.TryParse(Console.ReadLine(), out categoryId);
                                for (int i = 0; i < categoryIndex; i++)
                                {
                                    if (categoryId == categories[i].Id)
                                    {
                                        categoryFound = true;
                                    }
                                }

                                if (!categoryFound)
                                {
                                    Console.WriteLine($"There is no category named {categoryId}");
                                    Console.WriteLine("Enter any key for main menu");
                                    Console.ReadKey();
                                    break;
                                }

                                try
                                {
                                    products = ProductRepository.Create(products, productIndex, categoryId);
                                }
                                catch (ArgumentNullException)
                                {
                                    Console.WriteLine("Name, Description and Category Id is required!");
                                    Console.WriteLine("Enter any key for main menu");
                                    Console.ReadKey();
                                    break;
                                }
                                productIndex = productIndex + 1;


                                Console.WriteLine("Press any key for main menu");
                                Console.ReadKey();
                                #endregion

                                break;
                            case "2":
                                Console.Clear();
                                #region Category List

                                ProductRepository.List(products, productIndex);

                                Console.ReadKey();

                                #endregion
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                subMenuTerminator = true;
                                break;
                        }
                    } while (!subMenuTerminator);
                }


            } while (!mainMenuTerminator);


            //Category cat = new Category();
            //cat.Name = "Laptop";
            //cat.Description = "Laptop";
            //cat.Id = 1;
            //Console.WriteLine(cat.ToString());

            //Category cat1 = new Category();
            //cat1.Name = "Bag";
            //cat1.Description = "Bag";
            //cat1.Id = 2;
            //Console.WriteLine(cat1.ToString());

            //Product prod = new Product();
            //prod.Name = "Lenovo";
            //prod.Description = "Lenovo";
            //prod.Id = 1;
            //prod.Category = cat;
            //cat.Products[0] = prod;
            //Console.WriteLine(prod.ToString());

            //Product prod1 = new Product();
            //prod1.Name = "Violet";
            //prod1.Description = "Violet";
            //prod1.Id = 2;
            //prod1.Category = cat1;
            //cat1.Products[0] = prod1;
            //Console.WriteLine(prod1.ToString());

            //Product prod2 = new Product();
            //prod2.Name = "Leather Violet";
            //prod2.Description = "Leather Violet";
            //prod2.Id = 3;
            //prod2.Category = cat1;
            //cat1.Products[1] = prod2;
            //Console.WriteLine(prod2.ToString());


            //Console.WriteLine("List of Products in Bag Category");
            //foreach (var item in cat1.Products)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("List of Products in Laptop Category");
            //foreach (var item1 in cat.Products)
            //{
            //    Console.WriteLine(item1);
            //}


        }
    }
}
