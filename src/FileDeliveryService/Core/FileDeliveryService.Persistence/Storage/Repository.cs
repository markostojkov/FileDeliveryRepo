using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using FileDeliveryService.Persistence.DatabaseContext;
using FileDeliveryService.Persistence.Entities.Base;
using FileDeliveryService.Persistence.Storage.Interfaces;

namespace FileDeliveryService.Persistence.Storage
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        public Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected ApplicationDbContext DbContext { get; }

        protected DbSet<T> DbSet { get; }

        public IQueryable<T> All()
        {
            return DbSet;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.SingleOrDefaultAsync(f => f.Id == id);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public async Task<T> GetByUidAsync(Guid uid)
        {
            return await DbSet.SingleOrDefaultAsync(f => f.Uid == uid);
        }
    }
}