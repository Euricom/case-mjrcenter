using Euricom.MjrCenter.Shared.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Euricom.MjrCenter.VoucherApi.Model
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

        public DbSet<VoucherCode> Vouchers { get; set; }
    }
}
