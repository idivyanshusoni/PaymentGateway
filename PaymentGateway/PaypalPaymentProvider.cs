using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway
{
    public class PaypalPaymentProvider : IPaymentProvider
    {
        public string ProviderName => "PayPal";

        public async Task<ProviderPaymentResult> ProcessPaymentAsync(Payment payment, CancellationToken ccToken)
        {
            //HTTP calls to the PayPal for the payment processing.

            await Task.Delay(100, ccToken);

            return new ProviderPaymentResult(

                );
        }
    }
}
