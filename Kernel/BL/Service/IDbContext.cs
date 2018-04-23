using System.Collections.Generic;
using System.Threading.Tasks;
using VerFarm.Kernel.Data.Entity;

namespace VerFarm.Kernel.BL.Service
{
    public interface IDbContext
    {
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : BaseEntity;

        Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : BaseEntity;

        Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;

        Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;

        Task<bool> DeleteAsync<TEntity>(int id) where TEntity : BaseEntity;
    }
}