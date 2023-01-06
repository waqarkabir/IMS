using Entities;
using Infrastructure;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Inventory Management System (Developed by Waqar Kabir)";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Category[] categories = new Category[10];
            Product[] products = new Product[100];
            int categoryIndex = 0;
            int productIndex = 0;
            bool mainMenuTerminator = false;
            string input;
            

            do
            {
                Console.WriteLine("Inventory Management System (IMS)");
                Console.WriteLine("___________________________________");
                Console.WriteLine("IMS Main Menu");
                Console.WriteLine("Select a menu");
                Console.WriteLine("1) Category Management");
                Console.WriteLine("2) Product Management");
                Console.WriteLine("Press any other key to exit Program");
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


                                ProductRepository.List(products, productIndex);

                                Console.ReadKey();

                                #endregion
                                break;
                            case "3":
                                Console.Clear();
                                #region Search Category
                                bool categoryEmpty = CategoryRepository.List(categories, categoryIndex);
                                bool productFound = false;
                                if (!categoryEmpty)
                                {
                                    Console.WriteLine("Empty Category List");
                                    break;
                                }

                                Console.WriteLine("Enter a category to search");
                                string searchString = Console.ReadLine();
                                if (string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString))
                                {
                                    Console.WriteLine("Search string cannot be null!");
                                    return;
                                }
                                int category = CategoryRepository.SearchById(categories, categoryIndex, searchString);
                                Console.WriteLine("Products List");
                                for (int j = 0; j < productIndex; j++)
                                {
                                    if (category == Convert.ToInt32(searchString)-1)
                                    {
                                        Console.WriteLine($"Product Id:{j + 1}, {products[j]}");
                                        productFound = true;
                                        break;
                                    }
                                }

                                if (!productFound)
                                {
                                    Console.WriteLine($"No product with category id '{searchString}' is available");
                                    Console.WriteLine("Press any key for main menu");
                                    Console.ReadKey();
                                    subMenuTerminator = true;
                                    break;
                                }


                                Console.ReadKey();
                                #endregion
                                break;
                            case "4":
                                Console.Clear();
                                #region Update Category
                                CategoryRepository.Update(categories);
                                Console.ReadKey();
                                #endregion
                                break;
                            case "5":
                                #region Delete Category

                                Console.Clear();
                                bool categoryEmptyCheck = CategoryRepository.List(categories, categoryIndex);
                                if (!categoryEmptyCheck)
                                {
                                    Console.WriteLine("Empty Category List");
                                    break;
                                }

                                Console.WriteLine("Enter a category to search");
                                string searchCatForDelete = Console.ReadLine();
                                if (string.IsNullOrEmpty(searchCatForDelete) || string.IsNullOrWhiteSpace(searchCatForDelete))
                                {
                                    Console.WriteLine("Search string cannot be null!");
                                    return;
                                }
                                int categoryForDelete = CategoryRepository.SearchById(categories, categoryIndex, searchCatForDelete);

                                try
                                {
                                    categories = CategoryRepository.Delete(categories, categoryIndex, categoryForDelete);
                                }
                                catch (ArgumentNullException)
                                {
                                    Console.WriteLine("Category Id not found!");
                                    Console.WriteLine("Enter any key for main menu");
                                    Console.ReadKey();
                                    break;
                                }
                                categoryIndex = categoryIndex - 1;
                                Console.WriteLine("Press any key for main menuu");
                                Console.ReadKey();
                                #endregion
                                break;
                            case "6":
                                subMenuTerminator = true;
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                subMenuTerminator = true;
                                break;
                        }
                    } while (!subMenuTerminator);
                }
                if (input == "2")
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
                                input = Console.ReadLine();
                                int.TryParse(input, out categoryId);
                                for (int i = 0; i < categoryIndex; i++)
                                {
                                    if (categoryId - 1 == categories[i].Id)
                                    {
                                        categoryFound = true;
                                    }
                                }

                                if (!categoryFound)
                                {
                                    Console.WriteLine($"There is no  category id named {input}");
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
                                #region Product List

                                ProductRepository.List(products, productIndex);
                                Console.WriteLine("Enter any key to exit");
                                Console.ReadKey();

                                #endregion
                                break;
                            case "3":
                                #region Search Product

                                Console.Clear();

                                ProductRepository.Search(products, productIndex);

                                Console.WriteLine("Press any key for main menu");
                                Console.ReadKey();
                                #endregion
                                break;
                            case "4":
                                Console.Clear();
                                #region Update Product
                                ProductRepository.Update(products);
                                Console.ReadKey();
                                #endregion
                                break;
                            case "5":
                                #region Delete Product

                                Console.Clear();
                                bool productEmpty = ProductRepository.List(products, productIndex);
                                bool productFound = false;
                                if (!productEmpty)
                                {
                                    Console.WriteLine("Empty Product List");
                                    break;
                                }

                                Console.WriteLine("Enter a product id");

                                int productId = -1;
                                input = Console.ReadLine();
                                int.TryParse(input, out productId);
                                for (int i = 0; i < productIndex; i++)
                                {
                                    if (productId == products[i].Id)
                                    {
                                        productFound = true;
                                    }
                                }

                                if (!productFound)
                                {
                                    Console.WriteLine($"There is no product having id {input}");
                                    Console.WriteLine("Enter any key for main menu");
                                    Console.ReadKey();
                                    break;
                                }

                                try
                                {
                                    products = ProductRepository.Delete(products, productIndex, productId);
                                }
                                catch (ArgumentNullException)
                                {
                                    Console.WriteLine("Product Id not found!");
                                    Console.WriteLine("Enter any key for main menu");
                                    Console.ReadKey();
                                    break;
                                }
                                productIndex = productIndex - 1;
                                Console.WriteLine("Press any key for main menuu");
                                Console.ReadKey();
                                #endregion
                                break;
                            case "6":
                                subMenuTerminator = true;
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
                    subMenuTerminator = true;
                }
            } while (!mainMenuTerminator);
        }
    }
}
