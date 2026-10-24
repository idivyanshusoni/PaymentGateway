using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway
{
    public sealed record PaymentRequest
    {
        ///OrderId,
        ///Amount,
        ///Currency,
        ///PaymentMethod,
        ///IdempotencyKey
    }
}
