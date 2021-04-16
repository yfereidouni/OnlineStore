using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Domain.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.EndPoints.UI.MVC.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
