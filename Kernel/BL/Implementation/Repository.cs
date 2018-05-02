using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerFarm.Kernel.BL.Service;
using VerFarm.Kernel.Data.Entity;
using VerFarm.Kernel.Model.DTO;

namespace VerFarm.Kernel.BL.Implemantation
{
    public class Repository<TEntity, TDto> : IService<TDto>
        where TEntity : BaseEntity
        where TDto : IBaseDTO
    {
        protected readonly IDbContext Db;
        protected readonly IMapper Mapper;

        public Repository(IDbContext dbContext, IMapper mapper)
        {
            Db = dbContext;
            Mapper = mapper;
        }

        public async Task<IBaseDTO> Add(IBaseDTO dto)
        {
            try
            {
                TEntity entity = Mapper.Map<TEntity>(dto);
                entity = await Db.AddAsync(entity);
                return Mapper.Map<TDto>(entity);
            }
            catch (Exception ex)
            {
                return await Task.FromResult<IBaseDTO>(null);
                //return null;
            }
        }

        public async Task<IBaseDTO> GetById(int id)
        {
            try
            {
                TEntity entity = await Db.GetByIdAsync<TEntity>(id);
                return Mapper.Map<TDto>(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IBaseDTO> Update(IBaseDTO dto)
        {
            try
            {
                TEntity entity = Mapper.Map<TEntity>(dto);
                TEntity newEntity = await Db.UpdateAsync(entity);
                return Mapper.Map<TDto>(newEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<IBaseDTO>> GetAll()
        {
            try
            {
                IEnumerable<TEntity> entityies = await Db.GetAllAsync<TEntity>();
                return entityies.Select(e => (IBaseDTO)Mapper.Map<TDto>(e));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                return await Db.DeleteAsync<TEntity>(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
