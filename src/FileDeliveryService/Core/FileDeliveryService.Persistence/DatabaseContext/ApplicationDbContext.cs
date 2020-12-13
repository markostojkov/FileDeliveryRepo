using Microsoft.EntityFrameworkCore;

using FileDeliveryService.Persistence.Configurations;
using FileDeliveryService.Persistence.Entities;

namespace FileDeliveryService.Persistence.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Packet> Packets { get; set; }

        public DbSet<PacketCountry> PacketCountries { get; set; }

        public DbSet<Entities.Version> Versions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            const string dboSchema = "dbo";

            modelBuilder.ApplyConfiguration(new CountryConfig(dboSchema));
            modelBuilder.ApplyConfiguration(new PacketConfig(dboSchema));
            modelBuilder.ApplyConfiguration(new PacketCountryConfig(dboSchema));
            modelBuilder.ApplyConfiguration(new VersionConfig(dboSchema));
        }
    }
}
