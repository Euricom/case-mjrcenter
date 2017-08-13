using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Euricom.MjrCenter.ScheduleApi.Utilities.Model;
using Microsoft.EntityFrameworkCore;

namespace Euricom.MjrCenter.ScheduleApi.Model.Mappings
{
    public class VenueMap : IEntityTypeConfiguration<Venue>
    {
        public void Map(EntityTypeBuilder<Venue> venue)
        {
            venue.ToTable("Venues");
            venue.HasKey(v => v.Id);
            venue.Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
            venue.Property(v => v.Name).IsRequired().HasMaxLength(100);
            venue.HasOne(v => v.Extended).WithOne()
                .HasPrincipalKey<Venue>(v => v.Id)
                .HasForeignKey<VenueExtended>(ve => ve.Id);
        }
    }
}