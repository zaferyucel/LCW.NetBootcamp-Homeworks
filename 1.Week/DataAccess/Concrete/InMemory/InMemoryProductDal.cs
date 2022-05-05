using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private static List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product {ProductId =1, CategoryId = 1, ProductName = "Asus Laptop", UnitPrice = 17000, UnitsInStock = 150, Description = "Asus Laptop"},
                new Product {ProductId =2, CategoryId = 2, ProductName = "Iphone 11", UnitPrice = 12000, UnitsInStock = 10, Description = "Iphone 11"},
                new Product {ProductId =3, CategoryId = 2, ProductName = "Samsung S20", UnitPrice = 11000, UnitsInStock = 45, Description = "Samsung S20"},
                new Product {ProductId =4, CategoryId = 1, ProductName = "Lenovo Laptop", UnitPrice = 13000, UnitsInStock = 80, Description = "Lenovo Laptop"},
                new Product {ProductId =5, CategoryId = 3, ProductName = "Kulaklık ", UnitPrice = 500, UnitsInStock = 25, Description = "Kulaklık"},
                new Product {ProductId =6, CategoryId = 4, ProductName = "Şarj Aleti ", UnitPrice = 300, UnitsInStock = 250, Description = "Şarj Aleti"},
                new Product {ProductId =7, CategoryId = 2, ProductName = "Xiomi Redmi ", UnitPrice = 5000, UnitsInStock = 20, Description = "Xiomi Redmi"},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(int id)
        {
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == id);
            _products.Remove(productToDelete);
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.Description = product.Description;
        }   

        public Product GetById(int id)
        {
            return _products.SingleOrDefault(p => p.ProductId == id);
        }

        public List<Product> GetAll()
        {
            return _products;
        }
    }
}
