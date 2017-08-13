using Euricom.MjrCenter.VoucherApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.VoucherApi.BusinessComponents
{
    public interface IVoucherCodeBusinessComponent
    {
        Task<VoucherCode> GenerateVoucherCode(VoucherStatus status, short numberOfSeats, long scheduleId);
        Task<IList<VoucherCode>> GetAll();
        Task<VoucherCode> GetById(long id);
        Task<bool> Update(VoucherCode venue);
        Task<bool> DeleteById(long id);
    }
}
