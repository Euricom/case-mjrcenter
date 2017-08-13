using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euricom.MjrCenter.Shared.Data.Model
{
    public interface IEntityTypeConfiguration<T> where T : class
    {
        void Map(EntityTypeBuilder<T> entityBuilder,string provider = null);
    }
}
