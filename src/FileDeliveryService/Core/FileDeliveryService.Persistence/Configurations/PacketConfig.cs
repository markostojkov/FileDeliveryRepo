using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FileDeliveryService.Persistence.Configurations.Base;
using FileDeliveryService.Persistence.Entities;

namespace FileDeliveryService.Persistence.Configurations
{
    public class PacketConfig : BaseConfig<Packet>
    {
        public PacketConfig(string schema) : base(schema)
        {
        }

        public override void Configure(EntityTypeBuilder<Packet> builder)
        {
            base.Configure(builder);

            builder.ToTable("Packet", Schema);

            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.LogoUrl).HasColumnName(@"LogoUrl").HasColumnType("nvarchar").HasMaxLength(400).IsRequired();

        }
    }
}
