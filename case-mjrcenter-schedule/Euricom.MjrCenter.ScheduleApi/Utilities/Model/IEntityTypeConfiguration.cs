using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euricom.MjrCenter.ScheduleApi.Utilities.Model
{
    public interface IEntityTypeConfiguration<T> where T : class
    {
        void Map(EntityTypeBuilder<T> entityBuilder);
    }
}