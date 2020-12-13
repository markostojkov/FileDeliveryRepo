using System.Collections.Generic;

using FileDeliveryService.Persistence.Entities.Base;

namespace FileDeliveryService.Persistence.Entities
{
    public class Packet : BaseEntity
    {
        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public IEnumerable<Version> Versions { get; set; }

        public IEnumerable<PacketCountry> PacketAvaliableInCountries { get; set; }

        public Packet()
        {
            Versions = new List<Version>();
            PacketAvaliableInCountries = new List<PacketCountry>();
        }
    }
}
