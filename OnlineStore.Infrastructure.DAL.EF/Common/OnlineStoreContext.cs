using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Domain.Categories;
using OnlineStore.Core.Domain.Orders;
using OnlineStore.Core.Domain.Products;
using OnlineStore.Infrastructure.DAL.EF.Categories;
using OnlineStore.Infrastructure.DAL.EF.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.DAL.EF.Common
{
    public class OnlineStoreContext : DbContext
    {
        public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
