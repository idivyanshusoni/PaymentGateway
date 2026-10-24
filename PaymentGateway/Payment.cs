using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway
{
    public sealed class Payment
    {
        public Guid Id { get; private set; }

        public string OrderId { get; private set; }

        public decimal Amount { get; private set; }

        public string Currency { get; private set; }

        public PaymentMethodType PaymentMethod { get; private set; }

        public PaymentStatus Status { get; private set; }

        public string IdempotencyKey { get; private set; }

        public string? ProviderPaymentId { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset UpdatedAt { get; private set; }

        public Payment(string orderId, decimal amount, string currency, PaymentMethodType paymentMethod, string idempotencyKey)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                throw new ArgumentException("Order ID is required.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be positive.");

            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency is required.");

            if (string.IsNullOrWhiteSpace(idempotencyKey))
                throw new ArgumentException("Idempotency key is required.");

            Id = Guid.NewGuid();
            OrderId = orderId;
            Amount = amount;
            Currency = currency;
            PaymentMethod = paymentMethod;
            IdempotencyKey = idempotencyKey;

            Status = PaymentStatus.Initiated;
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = CreatedAt;
        }

        public void MarkProcessing()
        {
            if (Status != PaymentStatus.Initiated)
                throw new InvalidOperationException($"Cannot process payment in state {Status}.");

            Status = PaymentStatus.Processing;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void MarkSucceeded(string providerPaymentId)
        {
            if (Status != PaymentStatus.Processing &&
                Status != PaymentStatus.Unknown)
                throw new InvalidOperationException($"Cannot succeed payment in state {Status}.");

            ProviderPaymentId = providerPaymentId;
            Status = PaymentStatus.Succeeded;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void MarkFailed()
        {
            if (Status != PaymentStatus.Processing &&
                Status != PaymentStatus.Unknown)
                throw new InvalidOperationException($"Cannot fail payment in state {Status}.");

            Status = PaymentStatus.Failed;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void MarkUnknown()
        {
            if (Status != PaymentStatus.Processing)
                throw new InvalidOperationException($"Cannot mark payment unknown in state {Status}.");

            Status = PaymentStatus.Unknown;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
