using System;

namespace FileDeliveryService.Persistence.Entities.Base
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        Guid Uid { get; set; }
    }
}