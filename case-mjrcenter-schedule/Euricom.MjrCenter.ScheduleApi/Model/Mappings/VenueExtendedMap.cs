using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Euricom.MjrCenter.ScheduleApi.Utilities.Model;
using Microsoft.EntityFrameworkCore;

namespace Euricom.MjrCenter.ScheduleApi.Model.Mappings
{
    public class VenueExtendedMap : IEntityTypeConfiguration<VenueExtended>
    {
        public void Map(EntityTypeBuilder<VenueExtended> venueExtended)
        {
            venueExtended.ToTable("VenuesExtended");
            venueExtended.HasKey(v=>v.Id);
            venueExtended.Property(v=>v.Id).IsRequired();
        }
    }
}