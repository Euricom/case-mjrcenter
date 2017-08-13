
namespace Euricom.MjrCenter.VoucherApi.Model
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
            InitializeVoucher();
            mjrContext.SaveChanges();
        }

        private void InitializeVoucher()
        {
            mjrContext.Vouchers.Add(new VoucherCode()
            {
                Code = "A8D5686RE",
                NumberOfFreeSeats = 30,
                ScheduleId = 1,
                Status = VoucherStatus.New
            });
            mjrContext.SaveChanges();
        }
    }
}
