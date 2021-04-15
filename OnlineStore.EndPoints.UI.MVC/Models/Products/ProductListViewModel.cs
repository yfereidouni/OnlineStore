using OnlineStore.EndPoints.UI.MVC.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Core.Domain.Products;

namespace OnlineStore.EndPoints.UI.MVC.Models.Products
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
