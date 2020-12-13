using System;
using System.Collections.Generic;

namespace FileDeliveryService.Contracts.FileDelivery.Response
{
    public sealed class PaginatedPacketsResponse
    {
        public int Count { get; }

        public int CurrentPage { get; }

        public List<PaginatedPacket> PaginatedPackets { get; }

        public PaginatedPacketsResponse(int pages, int currentPage, List<PaginatedPacket> paginatedPackets)
        {
            PaginatedPackets = paginatedPackets;
            Count = pages;
            CurrentPage = currentPage;
        }
    }

    public sealed class PaginatedPacket
    {
        public Guid Uid { get; }

        public string Name { get; }

        public string LogoUrl { get; }

        public PaginatedPacket(Guid uid, string name, string logoUrl)
        {
            Uid = uid;
            Name = name;
            LogoUrl = logoUrl;
        }
    }
}
