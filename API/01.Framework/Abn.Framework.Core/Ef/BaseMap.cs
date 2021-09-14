using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 
namespace Abn.Framework.Core.Ef
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : class
    {
        public string TableName { get; set; }

        public BaseMap(string tableName) => TableName = tableName;

        public abstract void Configure(EntityTypeBuilder<T> builder);
    }
}
