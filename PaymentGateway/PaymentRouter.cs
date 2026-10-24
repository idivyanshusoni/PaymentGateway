using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway
{
    public class PaymentRouter : IPaymentRouter
    {
        private readonly IReadOnlyDictionary<PaymentMethodType, IPaymentProvider> _providers;

        public PaymentRouter(IReadOnlyDictionary<PaymentMethodType, IPaymentProvider> providers)
        {
            _providers = providers;
        }

        public IPaymentProvider GetProvider(Payment payment)
        {
            if (!_providers.TryGetValue(payment.PaymentMethod, out var provider))
                throw new InvalidOperationException($"No provider configured for {payment.PaymentMethod}.");
            return provider;
        }
    }
}
