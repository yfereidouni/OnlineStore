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
        public List<Product> GetProducts()
        {
            return _onlineStoreContext.Products.Include(c => c.Category).ToList();
        }
    }
}
