using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_OOP.Products
{
    public enum ProductType
    {
        Red,
        White
    }
    public class Product
    {
        private string _title;
        private string _description; 
        private double _price;
        private string _image;
        private ProductType _type;

        private Guid _id;
        public Guid ID { get { return _id; } set { _id = value; } }

        public string Title { get { return _title; } set { _title = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        public string Image { get { return _image; } set { _image = value; } }
        public ProductType Type { get { return _type; } set { _type = value; } }
        public Product()
        {
            _id = Guid.NewGuid();
        }
        public Product(string Title, string Description, double Price, string Image, ProductType Type) : this()
        {
            this.Title = Title;
            this.Description = Description;
            this.Price = Price;
            this.Image = Image;
            this.Type = Type;
        }
    }
}
