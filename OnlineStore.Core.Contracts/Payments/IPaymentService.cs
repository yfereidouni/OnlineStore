using OnlineStore.Core.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Core.Contracts.Payments
{
    public interface IPaymentService
    {
        RequestPaymentResult RequestPayment(string amount,string mobile,string factorNumber, string description);
        VerifyPayemtnResult VerifyPayment(string token);
    }
}
