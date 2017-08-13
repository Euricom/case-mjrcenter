using System.Collections.Generic;
using System.Threading.Tasks;
using Euricom.MjrCenter.RegistrationApi.Model;

namespace Euricom.MjrCenter.RegistrationApi.BusinessComponents
{
    public interface ICustomerBusinessComponent
    {
        Task<Customer> Create(Customer customer);
        Task<IList<Customer>> GetAll(int pageIndex = 1, int pageSize = 100);
        Task<Customer> GetById(long Id, bool includeDeleted);
        Task<bool> SoftDeleteById(long id, bool deleted);
        Task<bool> Update(Customer customer, bool includeDeleted);
    }
}