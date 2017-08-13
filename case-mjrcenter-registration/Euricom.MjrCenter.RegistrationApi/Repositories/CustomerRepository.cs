using Euricom.MjrCenter.RegistrationApi.Model;
using Euricom.MjrCenter.Shared.Data.Repositories;

namespace Euricom.MjrCenter.RegistrationApi.Repositories
{
    public class CustomerRepository : BaseRepository<MjrContext,Customer>, ICustomerRepository
    {
       public CustomerRepository(MjrContext context) : base(context) { }
    }
}
