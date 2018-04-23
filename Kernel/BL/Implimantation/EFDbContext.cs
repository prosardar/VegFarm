using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.BL.Service;

namespace VerFarm.Kernel.BL.Implimantation
{
    public class DbContext<TEntity> : IDbContext<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public DbContext(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            DbSet<TEntity> set = _context.Set<TEntity>();
            return await set.FindAsync(id);
        }


        public async Task<TEntity> AddAsync(TEntity entity)
        {
            DbSet<TEntity> set = _context.Set<TEntity>();
            var newEntity = set.Add(entity);
            await _context.SaveChangesAsync();
            return newEntity;
        }


        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                DbEntityEntry<TEntity> dee = _context.Entry(entity);
                dee.CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return dee.Entity;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            DbSet<TEntity> set = _context.Set<TEntity>();            
            try
            {
                var entity = await set.FindAsync(id);
                set.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
