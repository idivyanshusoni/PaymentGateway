using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway
{
    public enum PaymentStatus
    {
        Initiated,
        Processing,
        Succeeded,
        Failed,
        Unknown,
        ActionRequired,
        Cancelled,
        PartiallyRefunded,
        Refunded,
    }
}
