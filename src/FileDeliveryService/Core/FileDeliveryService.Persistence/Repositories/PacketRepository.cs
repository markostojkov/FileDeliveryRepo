using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using FileDeliveryService.Common.ValueObjects;
using FileDeliveryService.Contracts.FileDelivery.Response;
using FileDeliveryService.Persistence.Entities;
using FileDeliveryService.Persistence.Repositories.Interfaces;
using FileDeliveryService.Persistence.Storage.Interfaces;
using FileDeliveryService.Persistence.Mappers;
using System;
using System.Collections.Generic;

namespace FileDeliveryService.Persistence.Repository
{
    public class PacketRepository : IPacketRepository
    {
        public PacketRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public async Task<Packet> GetPacketWithVersionsByUid(Guid uid)
        {
            return await UnitOfWork.Packets.All()
                .Include(p => p.Versions)
                .SingleOrDefaultAsync(p => p.Uid.Equals(uid));
        }

        public async Task<PaginatedPacketsResponse> GetPacketsPaginated(PagingValue paging)
        {
            var databasePackets = await UnitOfWork.Packets.All()
                .OrderByDescending(p => p.Id)
                .Skip(paging.Skip).Take(paging.Take).ToListAsync();

            var databasePacketsCount = await UnitOfWork.Packets.All()
                .CountAsync();

            return databasePackets.ToPaginatedPacketsResponse(databasePacketsCount, paging.HumanReadablePage);
        }

        public async Task<bool> PacketWithUidExists(Guid uid)
        {
            var packet = await UnitOfWork.Packets.GetByUidAsync(uid);
            return packet != null;
        }

        public async Task<List<Country>> GetCountriesPacketIsAvaliableIn(Guid packetUid)
        {
            return await (from databasePacket in UnitOfWork.Packets.All()
                          join databasePacketCountry in UnitOfWork.PacketsCountries.All() on databasePacket.Id equals databasePacketCountry.PacketFk
                          join databaseCountry in UnitOfWork.Countries.All() on databasePacketCountry.CountryFk equals databaseCountry.Id
                          where packetUid == databasePacket.Uid
                          select databaseCountry).ToListAsync();
        }

        public async Task<PacketDetailResponse> GetPacketDetails(Guid packetUid)
        {
            var databasePacket = await UnitOfWork.Packets.All()
                 .Include(p => p.Versions)
                 .SingleOrDefaultAsync(p => p.Uid == packetUid);

            if (databasePacket is null) return null;

            return databasePacket.ToPacketDetailResponse();
        }
    }
}
