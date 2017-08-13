using Euricom.MjrCenter.Shared.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euricom.MjrCenter.VoucherApi.Model.Mappings
{
    public class VoucherCodeMap : IEntityTypeConfiguration<VoucherCode>
    {
        public void Map(EntityTypeBuilder<VoucherCode> voucher)
        {
            voucher.ToTable("VoucherCodes");
            voucher.HasKey(v => v.Id);
            voucher.HasAlternateKey(v => v.Code);
            voucher.Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
            voucher.Property(v => v.Code).IsRequired().HasMaxLength(9);

            voucher.Property(v => v.Status)
                    .HasDefaultValue(VoucherStatus.New)
                    .IsRequired();

            voucher.Property(v => v.NumberOfFreeSeats).IsRequired();

            //voucher.HasOne(v => v.Schedule).WithOne()
            //    .HasPrincipalKey<VoucherCode>(v => v.Id)
            //    .HasForeignKey<Schedule>(s => s.Id);
        }

    }
}
