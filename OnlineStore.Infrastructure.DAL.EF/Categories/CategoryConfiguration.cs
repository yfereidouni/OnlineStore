using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.DAL.EF.Categories
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(c => c.CategoryName);
            builder.Property(c => c.CategoryName).HasMaxLength(100).IsRequired();
            builder.HasData(
                new Category { CategoryId = 1, CategoryName = "Category02" },
                new Category { CategoryId = 2, CategoryName = "Category02" },
                new Category { CategoryId = 3, CategoryName = "Category03" },
                new Category { CategoryId = 4, CategoryName = "Category04" });
        }
    }
}
