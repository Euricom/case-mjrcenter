using System.Collections.Generic;
using System.Threading.Tasks;
using Euricom.MjrCenter.RegistrationApi.Model;

namespace Euricom.MjrCenter.RegistrationApi.BusinessComponents {
    public interface IPaymentBusinessComponent {

        Task<Payment> Create(Payment payment);
        Task<IList<Payment>> GetAll();
        Task<Payment> GetById(long id);
        Task<bool> DeleteById(long id);
        Task<bool> Update(Payment payment);
    }
}
