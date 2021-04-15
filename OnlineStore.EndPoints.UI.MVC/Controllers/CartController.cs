using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.Core.Domain.Carts;
using OnlineStore.Core.Domain.Products;
using OnlineStore.Infrastructure.DAL.EF.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.EndPoints.UI.MVC.Infrastructures;
using OnlineStore.EndPoints.UI.MVC.Models.Carts;

namespace OnlineStore.EndPoints.UI.MVC.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart _cart;

        public CartController(IProductRepository repo, Cart cart)
        {
            repository = repo;
            _cart = cart;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = _cart,
                ReturnUrl = returnUrl
            });

        }
        [HttpPost]
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Find(productId);
            if (product != null)
            {
                _cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productId,
        string returnUrl)
        {
            Product product = repository.Find(productId);
            if (product != null)
            {
                _cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
