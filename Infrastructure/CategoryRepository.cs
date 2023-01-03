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
            categories[categoryIndex] = category;
            Console.WriteLine($"Category Id: {categoryIndex + 1}, {category}");

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
                Console.WriteLine($"Category Id is {i + 1}, {categories[i]}");
            }

            return true;

        }
    }
}
