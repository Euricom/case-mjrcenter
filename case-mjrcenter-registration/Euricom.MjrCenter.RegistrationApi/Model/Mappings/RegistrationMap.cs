using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Euricom.MjrCenter.Shared.Data.Model;

namespace Euricom.MjrCenter.RegistrationApi.Model.Mappings
{
    public class RegistrationMap : IEntityTypeConfiguration<Registration>
    {
        public void Map(EntityTypeBuilder<Registration> registration)
        {
            registration.ToTable("Registrations");
            registration.HasKey(r => r.Id);
            registration.Property(r =>r.Id).IsRequired().ValueGeneratedOnAdd();
            registration.HasOne(r => r.RegistratedCustomer).WithMany()
                        .HasPrincipalKey(c => c.Id)
                        .HasForeignKey(r => r.CustomerId);
            registration.Property(r => r.ScheduleId).IsRequired();
            registration.Property(r => r.CustomerId).IsRequired();
            registration.Property(r =>r.User).IsRequired();
            registration.Property(r => r.Status).IsRequired();
            registration.Property(r => r.AmountPayable).IsRequired();
            registration.Ignore(r => r.VoucherCodes);
            registration.Property(r => r.VoucherCodesJson).HasMaxLength(250);
        }
    }
}
