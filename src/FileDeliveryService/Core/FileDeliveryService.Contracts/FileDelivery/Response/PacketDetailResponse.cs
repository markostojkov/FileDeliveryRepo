using System;
using System.Collections.Generic;

namespace FileDeliveryService.Contracts.FileDelivery.Response
{
    public class PacketDetailResponse
    {
        public PacketDetailResponse(Guid uid, string name, string logoUrl, List<VersionDetailResponse> versionDetails)
        {
            Uid = uid;
            Name = name;
            LogoUrl = logoUrl;
            VersionDetails = versionDetails;
        }

        public Guid Uid { get; }

        public string Name { get; }

        public string LogoUrl { get; }

        public List<VersionDetailResponse> VersionDetails { get; }
    }
}
