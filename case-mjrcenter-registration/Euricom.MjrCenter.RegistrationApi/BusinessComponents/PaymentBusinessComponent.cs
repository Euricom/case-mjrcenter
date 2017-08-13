using System.Collections.Generic;
using System.Threading.Tasks;
using Euricom.MjrCenter.RegistrationApi.Model;
using Euricom.MjrCenter.RegistrationApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Euricom.MjrCenter.RegistrationApi.BusinessComponents
{
    public class PaymentBusinessComponent : IPaymentBusinessComponent
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentBusinessComponent(IPaymentRepository paymentRepository) {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> Create(Payment payment)
        {
            await _paymentRepository.Add(payment);
            await _paymentRepository.Commit();
            return payment;
        }

        public async Task<bool> DeleteById(long id)
        {
            Payment payment = await GetById(id);
            if (payment == null){
                return false;
            }

            await _paymentRepository.Remove(payment);
            await _paymentRepository.Commit();

            return true;
        }

        public async Task<IList<Payment>> GetAll()
        {
            return await _paymentRepository.All.ToListAsync();
        }

        public Task<Payment> GetById(long id)
        {
            return _paymentRepository.All.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Update(Payment payment)
        {
            Payment dbPayment = await GetById(payment.Id);
            if (dbPayment == null) {
                return false;
            }

            dbPayment.PaymentMethod = payment.PaymentMethod;
            dbPayment.PaymentProcessor = payment.PaymentProcessor;
            dbPayment.PaymentStatus = payment.PaymentStatus;
            dbPayment.ProcessorTransactionId = payment.ProcessorTransactionId;
            dbPayment.TransactionDateTime = payment.TransactionDateTime;

            await _paymentRepository.Commit();
            return true;
        }
    }
}
