using Euricom.MjrCenter.RegistrationApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.RegistrationApi.BusinessComponents
{
    public interface IRegistrationBusinessComponent
    {
        Task<IList<Registration>> GetAll();
        Task<Registration> GetById(long id);
        Task<bool> Update(Registration registration);
        Task<Registration> Create(Registration registration);
        Task<bool> DeleteById(long id);
    }
}
