using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        private string _name;
        private string _description;
        private int _categoryId;

        public Product(string name, string description, int categoryId)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            EnteredOn = DateTime.Now;

        }
        public int Id { get; set; }

        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
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
                    throw new ArgumentNullException();
                }
                _description = value;
            }
        }

        public int CategoryId
        {
            get { return _categoryId; }
            private set
            {
                if (string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new ArgumentNullException();
                }
                _categoryId = value;
            }
        }

        public DateTime EnteredOn { get; private set; }
        public DateTime UpdatedOn { get; private set;}
        
        public Category Category { get; set; }

        public override string ToString()
        {
            return $"Product Id: {Id}, Name: {Name}, Category: {CategoryId}, Product Description: {Description}, Product Entered on {EnteredOn} ";
        }
    }
}