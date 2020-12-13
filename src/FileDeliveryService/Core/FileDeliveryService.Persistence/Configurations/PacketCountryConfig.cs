using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FileDeliveryService.Persistence.Configurations.Base;
using FileDeliveryService.Persistence.Entities;

namespace FileDeliveryService.Persistence.Configurations
{
    public class PacketCountryConfig : BaseConfig<PacketCountry>
    {
        public PacketCountryConfig(string schema) : base(schema)
        {
        }

        public override void Configure(EntityTypeBuilder<PacketCountry> builder)
        {
            base.Configure(builder);

            builder.ToTable("PacketCountry", Schema);

            builder.Property(x => x.PacketFk).HasColumnName(@"PacketFk").HasColumnType("int").IsRequired();
            builder.Property(x => x.CountryFk).HasColumnName(@"CountryFk").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Packet).WithMany(y => y.PacketAvaliableInCountries).HasForeignKey(z => z.PacketFk).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Country).WithMany(y => y.PacketCountries).HasForeignKey(z => z.CountryFk).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
