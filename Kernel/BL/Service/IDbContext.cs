﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace VerFarm.Kernel.BL.Service
{
    public interface IDbContext<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(int id);
    }
}