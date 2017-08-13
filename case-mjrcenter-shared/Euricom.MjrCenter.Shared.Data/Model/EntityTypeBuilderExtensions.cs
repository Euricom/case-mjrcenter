using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Euricom.MjrCenter.Shared.Data.Model
{
    public static class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<T> ToTableWithSchema<T> (this EntityTypeBuilder<T> builder, string tableName, string schema, string provider)
            where T : class
        {
            if (provider == Constants.SqliteProvider)
                builder.ToTable($"{schema}_{tableName}");
            else
                builder.ToTable(tableName, schema);

            return builder;
        }
    }
}
