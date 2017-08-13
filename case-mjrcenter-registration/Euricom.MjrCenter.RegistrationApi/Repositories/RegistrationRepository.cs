using Euricom.MjrCenter.RegistrationApi.Model;
using Euricom.MjrCenter.Shared.Data.Repositories;

namespace Euricom.MjrCenter.RegistrationApi.Repositories
{
    public class RegistrationRepository : BaseRepository<MjrContext, Registration>, IRegistrationRepository
    {
        public RegistrationRepository(MjrContext context) : base(context)
        {
        }
    }
}
