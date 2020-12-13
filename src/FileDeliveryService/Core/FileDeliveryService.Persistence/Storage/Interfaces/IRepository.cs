using System;
using System.Linq;
using System.Threading.Tasks;

namespace FileDeliveryService.Persistence.Storage.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        Task<T> GetByUidAsync(Guid uid);

        Task<T> GetByIdAsync(int id);

        void Insert(T entity);
    }
}