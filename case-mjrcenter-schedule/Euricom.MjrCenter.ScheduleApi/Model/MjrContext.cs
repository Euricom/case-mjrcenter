using Euricom.MjrCenter.ScheduleApi.Utilities.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Euricom.MjrCenter.ScheduleApi.Model
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

        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueExtended> VenueExtendeds { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerExtended> SpeakerExtendeds { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
