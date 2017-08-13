using Euricom.MjrCenter.ScheduleApi.Utilities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Euricom.MjrCenter.ScheduleApi.Model.Mappings
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Map(EntityTypeBuilder<Schedule> schedule)
        {
            schedule.ToTable("Schedules");
            schedule.HasKey(v => v.Id);
            schedule.Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();

            schedule.Property(v => v.BasePrice).IsRequired();
            schedule.Property(v => v.Comments).IsRequired();
            schedule.Property(v => v.Language).IsRequired();
            schedule.Property(v => v.Status).IsRequired();
            schedule.Property(v => v.Dates).IsRequired();
            schedule.Property(v => v.NumberOfSeats).IsRequired();
            schedule.Property(v => v.RegistrationDeadline).IsRequired();

            //FK to Mjr (ID van Mjr : MjrId + Version)
            //voucher.HasOne(v => v.MjrId).WithOne()
            //    .HasPrincipalKey<Mjr>(v => v.Id)
            //    .HasForeignKey<Mjr>(s => s.Id);

            //FK to Venue
            schedule.HasOne(s => s.Venue)
                    .WithOne()
                    .IsRequired();

            //FK to Speaker
            //schedule.HasOne(v => v.Speaker)
            //        .WithOne()
            //        .HasForeignKey(s => s.SpeakerId);

        }

    }
}
