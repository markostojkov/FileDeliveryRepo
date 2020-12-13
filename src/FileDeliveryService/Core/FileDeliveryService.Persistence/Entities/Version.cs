using System;

using FileDeliveryService.Persistence.Entities.Base;

namespace FileDeliveryService.Persistence.Entities
{
    public class Version : BaseEntity
    {
        public string VersionCode { get; set; }

        public DateTime VersionPublish { get; set; }

        public int VersionNumber { get; set; }

        public int PacketFk { get; set; }

        public virtual Packet Packet { get; set; }
    }
}
