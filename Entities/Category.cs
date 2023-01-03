using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category
    {
        private string _name;
        private string _description;
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
            EnteredOn = DateTime.Now;
        }
        public int Id { get; set; }

        public string Name
        {
            get { return _name; }
            private set {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value,"Name and description can't be null");
                }
                _name = value; 
            }
        }

        public string Description
        {
            get { return _description; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value,"Name and description can't be null");
                }
                _description = value;
            }
        }


        public DateTime EnteredOn { get; private set; }
        public DateTime UpdatedOn { get; private set; }
        public Product[] Products { get; set; } = new Product[10];

        public override string ToString()
        {            
            return $"Category Name: {Name}, Category Description: {Description},  Category Entered on {EnteredOn}";
        }
    }
}
