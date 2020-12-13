using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FileDeliveryService.Persistence.Configurations.Base;

namespace FileDeliveryService.Persistence.Configurations
{
    public class VersionConfig : BaseConfig<Entities.Version>
    {
        public VersionConfig(string schema) : base(schema)
        {
        }

        public override void Configure(EntityTypeBuilder<Entities.Version> builder)
        {
            base.Configure(builder);

            builder.ToTable("Version", Schema);

            builder.Property(x => x.VersionCode).HasColumnName(@"VersionCode").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.VersionPublish).HasColumnName(@"VersionPublish").HasColumnType("smalldatetime").IsRequired();
            builder.Property(x => x.VersionNumber).HasColumnName(@"VersionNumber").HasColumnType("int").IsRequired();
            builder.Property(x => x.PacketFk).HasColumnName(@"PacketFk").HasColumnType("PacketFk").IsRequired();

            builder.HasOne(x => x.Packet).WithMany(y => y.Versions).HasForeignKey(z => z.PacketFk).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
