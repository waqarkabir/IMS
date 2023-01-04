using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class CategoryRepository
    {
        public static Category[] Create(Category[] categories, int categoryIndex)
        {

            Category category = null;
            Console.WriteLine("Enter Category Name");
            
            string name = Console.ReadLine();
            Console.WriteLine("Enter Category Description");
            string description = Console.ReadLine();

            category = new Category(name,description);
            category.Id = categoryIndex+1;
            categories[categoryIndex] = category;
            Console.WriteLine(category);

            return categories;
        }

        public static bool List(Category[] categories, int categoryIndex)
        {
            if (categoryIndex == 0)
            {
                Console.WriteLine("There are no categories entered yet!. Enter a category first.");
                Console.WriteLine("Enter any key to exit");
                Console.ReadKey();
                return false;
            }
            Console.WriteLine("Category List");

            for (int i = 0; i < categoryIndex; i++)
            {
                Console.WriteLine(categories[i]);
            }

            return true;

        }

        public static void SearchByName(Category[] categories, int categoryIndex, string searchString)
        {

            bool stringFound = false;
            if (string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString))
            {
                Console.WriteLine("Search string cannot be null!");
                return;
            }


            for (int i = 0; i < categoryIndex; i++)
            {
                if (categories[i].Id.ToString().Contains(searchString))
                {
                    Console.WriteLine(categories[i]);
                    stringFound = true;
                }
            }

            if (!stringFound)
            {
                Console.WriteLine($"No category with name '{searchString}' is available, try again ");
            }
        }

        public static Category[] Update(Category[] categories)
        {

            Console.WriteLine("Enter a category id to edit");
            int searchIndex = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter New Category Name");

            string name = Console.ReadLine();

            Console.WriteLine("Enter New Category Description");

            string description = Console.ReadLine();
            categories[searchIndex - 1].Name = name;
            
            categories[searchIndex - 1].Description = description;

            Console.WriteLine("Category Updated");

            return categories;
        }

    }
}
