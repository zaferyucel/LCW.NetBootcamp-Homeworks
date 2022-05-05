using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasOne(m => m.category).
                WithMany(c => c.Products).
                HasForeignKey(s => s.CategoryId).
                OnDelete(DeleteBehavior.Restrict);

            entity.HasData(new Product { Id = 1, CategoryId = 1, Name = "Asus Laptop", UnitPrice = 17000, UnitsInStock = 150, Description = "Asus Laptop" },
                new Product { Id = 2, CategoryId = 2, Name = "Iphone 11", UnitPrice = 12000, UnitsInStock = 10, Description = "Iphone 11" },
                new Product { Id = 3, CategoryId = 2, Name = "Samsung S20", UnitPrice = 11000, UnitsInStock = 45, Description = "Samsung S20" },
                new Product { Id = 4, CategoryId = 1, Name = "Lenovo Laptop", UnitPrice = 13000, UnitsInStock = 80, Description = "Lenovo Laptop" },
                new Product { Id = 5, CategoryId = 3, Name = "Kulaklık ", UnitPrice = 500, UnitsInStock = 25, Description = "Kulaklık" },
                new Product { Id = 6, CategoryId = 4, Name = "Şarj Aleti ", UnitPrice = 300, UnitsInStock = 250, Description = "Şarj Aleti" },
                new Product { Id = 7, CategoryId = 2, Name = "Xiomi Redmi ", UnitPrice = 5000, UnitsInStock = 20, Description = "Xiomi Redmi" });
        }
    }
}
