using Euricom.MjrCenter.RegistrationApi.Model;
using Euricom.MjrCenter.Shared.Data.Repositories;

namespace Euricom.MjrCenter.RegistrationApi.Repositories
{
    public class PaymentRepository : BaseRepository<MjrContext, Payment>, IPaymentRepository
    {
       public PaymentRepository(MjrContext context) : base(context) { }
    }
}
