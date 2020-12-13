using System;
using System.Threading.Tasks;

namespace FileDeliveryService.Persistence.Repositories.Interfaces
{
    public interface IVersionRepository
    {
        Task<bool> PacketVersionExists(Guid packetUid, int version);
    }
}
