using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.BL.Service;
using VerFarm.Kernel.Data.Context;
using VerFarm.Kernel.Data.Entity;

namespace VerFarm.Kernel.BL.Implemantation
{
    public class EFDbContext : IDbContext
    {
        private readonly AuditDbContext _context;

        public EFDbContext(AuditDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : BaseEntity
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : BaseEntity
        {
            DbSet<TEntity> set = _context.Set<TEntity>();
            return await set.FindAsync(id);
        }

        public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            DbSet<TEntity> set = _context.Set<TEntity>();
            var newEntity = set.Add(entity);
            await _context.SaveChangesAsync();
            return newEntity;
        }

        public async Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            try
            {
                DbSet<TEntity> set = _context.Set<TEntity>();
                TEntity findedEntity = set.Find(entity.Id);
                if (findedEntity == null)
                {
                    return null;
                }
                DbEntityEntry<TEntity> entry = _context.Entry(findedEntity);
                entry.CurrentValues.SetValues(entity);                
                await _context.SaveChangesAsync();
                return entry.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync<TEntity>(int id) where TEntity : BaseEntity
        {
            DbSet<TEntity> set = _context.Set<TEntity>();
            try
            {
                var entity = await set.FindAsync(id);
                set.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
