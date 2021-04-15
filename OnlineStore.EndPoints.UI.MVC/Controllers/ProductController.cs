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
        private readonly IProductRepository ProductRepository;

        public ProductController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List(string category, int pageNumber = 1)
        {
            var model = new ProductListViewModel
            {
                Products = ProductRepository.GetProducts(category, 3, pageNumber),
                PagingInfo = new Models.Common.PagingInfo
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = 3,
                    TotalItems = ProductRepository.TotalCount(category)
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}
