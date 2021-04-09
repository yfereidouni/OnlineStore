using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Contracts.Products;
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
        public IActionResult List()
        {
            var products = ProductRepository.GetProducts();
            return View(products);
        }
    }
}
