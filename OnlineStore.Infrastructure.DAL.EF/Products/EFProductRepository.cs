using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.Core.Domain.Products;
using OnlineStore.Infrastructure.DAL.EF.Common;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Infrastructure.DAL.EF.Products
{
    public class EFProductRepository : IProductRepository
    {
        private readonly OnlineStoreContext _onlineStoreContext;
        public EFProductRepository(OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
        }

        public void Add(Product product)
        {
            _onlineStoreContext.Add(product);
            _onlineStoreContext.SaveChanges();
        }

        public Product Find(int productId)
        {
            return _onlineStoreContext.Products.Find(productId);
        }

        public List<Product> GetProducts(string category, int pageSize = 4, int pageNumber = 1)
        {
            //return _onlineStoreContext.Products.Include(c => c.Category).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            return _onlineStoreContext.Products.Where(c => string.IsNullOrWhiteSpace(category) || c.Category.CategoryName == category).Include(c => c.Category).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

        }
        public int TotalCount(string category)
        {
            //return _onlineStoreContext.Products.Count(c => string.IsNullOrWhiteSpace(category) || c.Category.CategoryName == category);
            return _onlineStoreContext.Products.Count(c => string.IsNullOrWhiteSpace(category) || c.Category.CategoryName == category);
        }
    }
}
