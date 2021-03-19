using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Interfaces.RepositryPattern;

namespace DataAccess
{
    public abstract class BaseRepository<TModel> : IRepository<TModel, Guid>
        where TModel : class, IEntity<Guid>
    {
        DbContext _context;
        DbSet<TModel> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TModel>();
        }

      

        public async Task AddAsync(TModel obj, CancellationToken cancellationToken = default)
        {
            _dbSet.Add(obj);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public async Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _dbSet.Find(id);
        }

        public async Task RemoveAsync(TModel item, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
        public async Task UpdateAsync(TModel item, CancellationToken cancellationToken = default)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
