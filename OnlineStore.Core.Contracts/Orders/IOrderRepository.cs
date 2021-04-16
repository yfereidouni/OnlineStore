using System;
using System.Collections.Generic;
using System.Text;
using OnlineStore.Core.Domain.Orders;

namespace OnlineStore.Core.Contracts.Orders
{
    public interface IOrderRepository
    {
        void SaveOrder(Order order);
        Order Find(int id);
        void SetTransactionId(int orderId, string token);
        void SetPaymentDone(string factorNumber);

        List<OrderHeader> Search(bool? Shipped);
        void Ship(int orderId);
    }
}
