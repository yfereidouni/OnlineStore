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
        public List<Product> GetProducts(int pageSize = 4, int pageNumber = 1)
        {
            return _onlineStoreContext.Products.Include(c => c.Category).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
        }

        public int TotalCount()
        {
            return _onlineStoreContext.Products.Count();
        }
    }
}
