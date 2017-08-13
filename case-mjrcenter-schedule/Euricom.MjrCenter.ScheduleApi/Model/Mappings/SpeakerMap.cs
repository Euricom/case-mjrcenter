using Euricom.MjrCenter.ScheduleApi.Utilities.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Euricom.MjrCenter.ScheduleApi.Model.Mappings
{
    public class SpeakerMap : IEntityTypeConfiguration<Speaker>
    {
        public void Map(EntityTypeBuilder<Speaker> speaker)
        {
            speaker.ToTable("Speakers");
            speaker.HasKey(s => s.Id);
            speaker.Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            speaker.Property(s => s.Name).IsRequired().HasMaxLength(100);
            speaker.HasOne(s => s.Extended).WithOne()
                    .HasPrincipalKey<Speaker>(s => s.Id)
                    .HasForeignKey<SpeakerExtended>(se => se.Id);
        }
    }
}
