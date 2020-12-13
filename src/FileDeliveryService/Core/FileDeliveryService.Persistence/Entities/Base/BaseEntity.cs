using System;

namespace FileDeliveryService.Persistence.Entities.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }

        public Guid Uid { get; set; }
    }
}
