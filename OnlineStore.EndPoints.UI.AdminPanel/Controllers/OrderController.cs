using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Contracts.Orders;


namespace OnlineStore.EndPoints.UI.AdminPanel.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IActionResult NewOrders()
        {
            var result = orderRepository.Search(false);
            return View(result);
        }
        public IActionResult ViewDetail(int id)
        {
            var order = orderRepository.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        [HttpPost]
        public IActionResult Ship(int id)
        {
            var order = orderRepository.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            orderRepository.Ship(id);
            return RedirectToAction(nameof(NewOrders));
        }
    }
}
