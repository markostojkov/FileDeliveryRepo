using System;
using System.Threading.Tasks;

using FileDeliveryService.Persistence.DatabaseContext;
using FileDeliveryService.Persistence.Entities;
using FileDeliveryService.Persistence.Storage.Interfaces;

namespace FileDeliveryService.Persistence.Storage
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private Repository<Country> CountriesValue { get; set; }

        private Repository<Packet> PacketsValue { get; set; }

        private Repository<PacketCountry> PacketCountriesValue { get; set; }

        private Repository<Entities.Version> VersionsValue { get; set; }

        private ApplicationDbContext DbContext { get; }

        private bool disposedValue;

        public IRepository<Country> Countries 
        { 
            get
            { 
                if (CountriesValue == null)
                {
                    CountriesValue = new Repository<Country>(DbContext);
                }

                return CountriesValue;
            }
        }

        public IRepository<Packet> Packets
        {
            get
            {
                if (PacketsValue == null)
                {
                    PacketsValue = new Repository<Packet>(DbContext);
                }

                return PacketsValue;
            }
        }

        public IRepository<PacketCountry> PacketsCountries
        {
            get
            {
                if (PacketCountriesValue == null)
                {
                    PacketCountriesValue = new Repository<PacketCountry>(DbContext);
                }

                return PacketCountriesValue;
            }
        }

        public IRepository<Entities.Version> Versions
        {
            get
            {
                if (VersionsValue == null)
                {
                    VersionsValue = new Repository<Entities.Version>(DbContext);
                }

                return VersionsValue;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        #region IDisposable Support

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        #endregion
    }
}
