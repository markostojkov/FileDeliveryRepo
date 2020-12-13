using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FileDeliveryService.Persistence.Configurations.Base;
using FileDeliveryService.Persistence.Entities;

namespace FileDeliveryService.Persistence.Configurations
{
    public class CountryConfig : BaseConfig<Country>
    {
        public CountryConfig(string schema) : base(schema)
        {
        }

        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);

            builder.ToTable("Country", Schema);

            builder.Property(x => x.Code).HasColumnName(@"Code").HasColumnType("char").HasMaxLength(2).IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Nicename).HasColumnName(@"Nicename").HasColumnType("nvarchar").HasMaxLength(80).IsRequired();
            builder.Property(x => x.Iso3).HasColumnName(@"Iso3").HasColumnType("char").HasMaxLength(3).IsRequired(false);
            builder.Property(x => x.Numcode).HasColumnName(@"Numcode").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Phonecode).HasColumnName(@"Phonecode").HasColumnType("int").IsRequired();
        }
    }
}
