using FileDeliveryService.Persistence.Entities.Base;

namespace FileDeliveryService.Persistence.Entities
{
    public class PacketCountry : BaseEntity
    {
        public int PacketFk { get; set; }

        public virtual Packet Packet { get; set; }

        public int CountryFk { get; set; }

        public virtual Country Country { get; set; }
    }
}
