namespace Euricom.MjrCenter.VoucherApi.Model
{
    public class VoucherCode
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public VoucherStatus Status { get; set; }
        public short NumberOfFreeSeats { get; set; }
        //One to one relationship with Schedule
        public long ScheduleId { get; set; }
    }
}
