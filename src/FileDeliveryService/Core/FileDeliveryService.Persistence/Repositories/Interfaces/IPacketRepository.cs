using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FileDeliveryService.Common.ValueObjects;
using FileDeliveryService.Contracts.FileDelivery.Response;
using FileDeliveryService.Persistence.Entities;

namespace FileDeliveryService.Persistence.Repositories.Interfaces
{
    public interface IPacketRepository
    {
        Task<PaginatedPacketsResponse> GetPacketsPaginated(PagingValue paging);

        Task<PacketDetailResponse> GetPacketDetails(Guid packetUid);

        Task<bool> PacketWithUidExists(Guid uid);

        Task<List<Country>> GetCountriesPacketIsAvaliableIn(Guid packetUid);

        Task<Packet> GetPacketWithVersionsByUid(Guid uid);
    }
}
