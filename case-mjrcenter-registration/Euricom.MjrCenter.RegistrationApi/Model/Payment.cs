using System;

namespace Euricom.MjrCenter.RegistrationApi.Model
{
    public class Payment
    {
        public long Id { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentProcessor { get; set; }
        public DateTimeOffset TransactionDateTime { get; set; }
        public long ProcessorTransactionId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
