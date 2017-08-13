using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Euricom.MjrCenter.Shared.Data.Model;

namespace Euricom.MjrCenter.RegistrationApi.Model.Mappings
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Map(EntityTypeBuilder<Payment> payment)
        {
            payment.ToTable("Payments");
            payment.HasKey(p => p.Id);
            payment.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            payment.Property(p => p.PaymentStatus).IsRequired();
            payment.Property(p => p.PaymentMethod).IsRequired();
            payment.Property(p => p.PaymentProcessor).IsRequired();
            payment.Property(p => p.ProcessorTransactionId).IsRequired();
            payment.Property(p => p.TransactionDateTime).IsRequired();
        }
    }
}
