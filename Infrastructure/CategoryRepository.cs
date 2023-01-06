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
            category.Id = categoryIndex;
            categories[categoryIndex] = category;
            Console.WriteLine($"Category Id: {categoryIndex+1}, {category}");

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
                Console.WriteLine($"Category Id: {categories[i].Id+1}, {categories[i]}");
            }

            return true;

        }

        public static int SearchById(Category[] categories, int categoryIndex, string searchString)
        {

            bool stringFound = false;
            int category = 0;

            for (int i = 0; i < categoryIndex; i++)
            {
                if (categories[i].Id.Equals(Convert.ToInt32(searchString)-1))
                {
                    Console.WriteLine($"Category Id: {categories[i].Id+1}, {categories[i]}");
                    stringFound = true;
                    category = categories[i].Id;
                    break;
                }
            }

            if (!stringFound)
            {
                Console.WriteLine($"No category with id '{searchString}' is available, try again ");
            }
            return category;
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


        public static Category[] Delete(Category[] categories, int categoryIndex, int categoryId)
        {

            for (int i = Convert.ToInt32(categoryId); i < categoryIndex; i++)
            {
                categories[i] = categories[i+1];
            }


            Category[] newArray = new Category[100];
            Array.Copy(categories, newArray, categoryIndex - 1);

            Console.WriteLine("Category Deleted");
            return newArray;
        }
    }
}
