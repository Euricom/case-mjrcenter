using System;
using System.Collections.Generic;
using System.Linq;

namespace Euricom.MjrCenter.RegistrationApi.Model
{
    internal class MjrContextInitializer
    {
        private MjrContext mjrContext;

        public MjrContextInitializer(MjrContext mjrContext)
        {
            this.mjrContext = mjrContext;
        }

        internal void Initialize()
        {
            InitializeCustomer();
            InitializePayment();

            mjrContext.SaveChanges();
        }

        private void InitializeCustomer()
        {
            mjrContext.Customers.Add(new Customer
            {
                FirstName = "Jos",
                LastName = "Peters",
                Email = "jos.peters@euri.com",
                Mobile = "+324 91 77 33 98",
                JobTitle = "Bootcamper",
                ContactBy = ContactMethod.Email,
                Interests = new string[] { "JS", "Html", "Voetbal" },
                InvoiceAddress = "Mechelen",
                InvoiceCompanyName = "Euricom",
                InvoiceVatOption = VatOption.VatNormal,
                InvoiceEnterpriseNumber = "BE0999999999"
            });
            mjrContext.SaveChanges();
        }       

        private void InitializePayment()
        {
            Payment paymentA = new Payment();
            paymentA.PaymentMethod = "Cash";
            paymentA.PaymentProcessor = "Payment processor A";
            paymentA.PaymentStatus = PaymentStatus.Succeeded;
            paymentA.TransactionDateTime = DateTimeOffset.Now;

            Payment paymentB = new Payment();
            paymentB.PaymentMethod = "Credit card";
            paymentB.PaymentProcessor = "Payment processor B";
            paymentB.PaymentStatus = PaymentStatus.Pending;
            paymentB.TransactionDateTime = DateTimeOffset.Now.AddDays(5).AddSeconds(1337);

            mjrContext.Payments.Add(paymentA);
            mjrContext.Payments.Add(paymentB);
            mjrContext.SaveChanges();
        }
    }
}
