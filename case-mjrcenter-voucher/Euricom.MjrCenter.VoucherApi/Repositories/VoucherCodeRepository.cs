using Euricom.MjrCenter.Shared.Data.Repositories;
using Euricom.MjrCenter.VoucherApi.Model;

namespace Euricom.MjrCenter.VoucherApi.Repositories
{
    public class VoucherCodeRepository : BaseRepository<MjrContext, VoucherCode>, IVoucherCodeRepository
    {
        public VoucherCodeRepository(MjrContext context) : base(context)
        { }


    }
}
