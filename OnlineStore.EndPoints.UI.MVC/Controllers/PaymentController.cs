using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineStore.Core.Contracts.Payments;
using OnlineStore.Core.Contracts.Orders;
using OnlineStore.Core.Domain.Payments;

namespace OnlineStore.EndPoints.UI.MVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IPaymentService payment;
        private readonly IConfiguration configuration;

        public PaymentController(IOrderRepository orderRepository,IPaymentService payment,IConfiguration configuration )
        {
            this.orderRepository = orderRepository;
            this.payment = payment;
            this.configuration = configuration;
        }
        // GET: /<controller>/
        [HttpPost]
        public IActionResult RequestPayment(int orderId)
        {
            var order = orderRepository.Find(orderId);
            var result = payment.RequestPayment(order.Lines.Sum(c => c.Product.Price).ToString(), "09122345677", order.OrderID.ToString(), $"Description {order.Name}");
            if (result.IsCorrect)
            {
                orderRepository.SetTransactionId(orderId, result.Token);
                return Redirect($"{configuration["PayIr:PaymentUrl"]}{result.Token}");
            }
            return View("PaymentError", result);
        }

        public IActionResult Verify(PaymentResult result)
        {
            if (result.IsCorrect)
            {
                var verifyResult = payment.VerifyPayment(result.Token.ToString());
                if (verifyResult.IsCorrect)
                {
                    orderRepository.SetPaymentDone(verifyResult.factorNumber);
                    return View("PaymentCompelete", verifyResult);
                }


            }
            return View("PaymentError", result);

        }
    }
}
