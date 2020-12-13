using System.Linq;
using System.Collections.Generic;

using FileDeliveryService.Contracts.FileDelivery.Response;
using FileDeliveryService.Persistence.Entities;

namespace FileDeliveryService.Persistence.Mappers
{
    public static class PacketMapper
    {
        public static PaginatedPacketsResponse ToPaginatedPacketsResponse(this List<Packet> packets, int packetsCount, int currentPage)
        {
            var mappedPackets = new List<PaginatedPacket>();

            if (packets.Any())
            {
                mappedPackets = packets.Select(p => new PaginatedPacket(p.Uid, p.Name, p.LogoUrl)).ToList();
            }

            return new PaginatedPacketsResponse(packetsCount, currentPage, mappedPackets);
        }

        public static PacketDetailResponse ToPacketDetailResponse(this Packet packet)
        {
            var versionResponse = new List<VersionDetailResponse>();

            if (packet.Versions.Any())
            {
                versionResponse = packet.Versions.Select(x => new VersionDetailResponse(x.VersionCode, x.VersionNumber)).ToList();
            }

            return new PacketDetailResponse(packet.Uid, packet.Name, packet.LogoUrl, versionResponse);
        }
    }
}
