using OnlineStore.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Contracts.Products
{
    public interface IProductRepository
    {
        int TotalCount(string category);
        List<Product> GetProducts(string category, int pageSize = 4, int pageNumber = 1);
        Product Find(int productId);
        void Add(Product product);
    }
}
