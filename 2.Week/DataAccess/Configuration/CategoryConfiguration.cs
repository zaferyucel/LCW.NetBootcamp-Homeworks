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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(
                new Category { Id = 1, Name = "Bilgisayar" },
                new Category { Id = 2, Name = "Telefon" },
                new Category { Id = 3, Name = "Kulaklık" },
                new Category { Id = 4, Name = "Aksesuar" });
        }
    }
}
