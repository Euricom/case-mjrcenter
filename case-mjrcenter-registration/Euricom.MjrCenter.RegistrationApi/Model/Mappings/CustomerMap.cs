using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Euricom.MjrCenter.Shared.Data.Model;

namespace Euricom.MjrCenter.RegistrationApi.Model.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Map(EntityTypeBuilder<Customer> customer)
        {
            customer.ToTable("Customers");
            customer.HasKey(c => c.Id);
            customer.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            customer.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            customer.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            customer.Property(c => c.JobTitle).IsRequired().HasMaxLength(50);
            customer.Property(c => c.Email).IsRequired().HasMaxLength(50);
            customer.Property(c => c.Mobile).IsRequired().HasMaxLength(20);
            customer.Ignore(c => c.Interests);
            customer.Property(c => c.InterestsJson).HasMaxLength(250);
            customer.Property(c => c.InvoiceCompanyName).IsRequired().HasMaxLength(80);
            customer.Property(c => c.InvoiceAddress).IsRequired().HasMaxLength(100);
            customer.Property(c => c.InvoiceVatOption).IsRequired();
            customer.Property(c => c.InvoiceEnterpriseNumber).IsRequired().HasMaxLength(14);
         }
    }
}
