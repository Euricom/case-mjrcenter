using Euricom.MjrCenter.ScheduleApi.Utilities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Euricom.MjrCenter.ScheduleApi.Model.Mappings
{
    public class SpeakerExtendedMap : IEntityTypeConfiguration<SpeakerExtended>
    {
        public void Map(EntityTypeBuilder<SpeakerExtended> speakerExtended)
        {
            speakerExtended.ToTable("SpeakerExtended");
            speakerExtended.HasKey(se => se.Id);
            speakerExtended.Property(v => v.Id).IsRequired();
        }
    }
}
