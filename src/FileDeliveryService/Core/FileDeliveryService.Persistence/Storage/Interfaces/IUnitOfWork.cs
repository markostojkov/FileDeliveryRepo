using System.Threading.Tasks;

using FileDeliveryService.Persistence.Entities;

namespace FileDeliveryService.Persistence.Storage.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Country> Countries { get; }

        IRepository<Packet> Packets { get; }

        IRepository<PacketCountry> PacketsCountries { get; }

        IRepository<Version> Versions { get; }

        Task<int> SaveAsync();
    }
}
