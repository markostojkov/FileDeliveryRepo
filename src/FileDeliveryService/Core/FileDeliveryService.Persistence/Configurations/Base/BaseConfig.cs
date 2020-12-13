using Microsoft.EntityFrameworkCore;

using FileDeliveryService.Persistence.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileDeliveryService.Persistence.Configurations.Base
{
    public abstract class BaseConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        protected BaseConfig(string schema)
        {
            Schema = schema;
        }

        protected string Schema { get; }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Uid).HasColumnName(@"UID").HasColumnType("uniqueidentifier").IsRequired();
        }
    }
}
