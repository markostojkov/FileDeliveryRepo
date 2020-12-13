using System.Collections.Generic;

using FileDeliveryService.Persistence.Entities.Base;

namespace FileDeliveryService.Persistence.Entities
{
    public class Country : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Nicename { get; set; }

        public string Iso3 { get; set; }

        public int? Numcode { get; set; }

        public int Phonecode { get; set; }

        public IEnumerable<PacketCountry> PacketCountries { get; set; }

        public Country()
        {
            PacketCountries = new List<PacketCountry>();
        }
    }
}
