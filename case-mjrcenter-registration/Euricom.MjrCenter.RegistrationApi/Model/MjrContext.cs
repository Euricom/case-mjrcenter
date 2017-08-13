using Euricom.MjrCenter.RegistrationApi.Utilities.Model;
using Euricom.MjrCenter.Shared.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Euricom.MjrCenter.RegistrationApi.Model
{
    public class MjrContext : DbContext
    {
        public MjrContext(DbContextOptions options) : base(options)
        {
            if (Database.EnsureCreated()) { new MjrContextInitializer(this).Initialize(); }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapFromAssembly(GetType().GetTypeInfo().Assembly);
        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
