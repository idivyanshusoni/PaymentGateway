using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway
{
    public interface IPaymentProvider
    {
        string ProviderName { get; }

        Task<ProviderPaymentResult> ProcessPaymentAsync(Payment payment, CancellationToken ccToken);
    }
}
