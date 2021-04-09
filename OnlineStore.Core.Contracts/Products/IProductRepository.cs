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
        List<Product> GetProducts();
    }
}
