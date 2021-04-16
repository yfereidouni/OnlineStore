using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.EndPoints.UI.MVC.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.EndPoints.UI.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult List(string category, int pageNumber = 1)
        {
            var model = new ProductListViewModel
            {
                Products = productRepository.GetProducts(category, 3, pageNumber),
                PagingInfo = new Models.Common.PagingInfo
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = 3,
                    TotalItems = productRepository.TotalCount(category)
                },
                CurrentCategory = category

            };
            return View(model);
        }
    }
}
