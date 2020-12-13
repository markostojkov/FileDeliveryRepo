using FileDeliveryService.Persistence.Repositories.Interfaces;
using FileDeliveryService.Persistence.Storage.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDeliveryService.Persistence.Repositories
{
    public class VersionRepository : IVersionRepository
    {
        public VersionRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public async Task<bool> PacketVersionExists(Guid packetUid, int version)
        {
            var a = await (from databasePacket in UnitOfWork.Packets.All()
                          join databaseVersion in UnitOfWork.Versions.All() on databasePacket.Id equals databaseVersion.PacketFk
                          where databasePacket.Uid == packetUid && databaseVersion.VersionNumber == version
                          select version).AnyAsync();

            return a;
        }
    }
}
