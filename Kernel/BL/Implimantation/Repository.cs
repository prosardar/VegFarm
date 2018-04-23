using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.BL.Service;
using VerFarm.Kernel.Data.Entity;
using VerFarm.Kernel.Model.DTO;

namespace VerFarm.Kernel.BL.Implimantation
{
    public class Repository<TEntity, TDto> : IService<TDto> 
        where TEntity : BaseEntity 
        where TDto : BaseDTO
    {
        protected readonly IDbContext Db;
        protected readonly IMapper Mapper;

        public Repository(IDbContext dbContext, IMapper mapper)
        {
            Db = dbContext;
            Mapper = mapper;
        }

        public async Task<TDto> Add(TDto dto)
        {
            TEntity entity = Mapper.Map<TEntity>(dto);
            entity = await Db.AddAsync(entity);
            return Mapper.Map<TDto>(entity);
        }

        public async Task<TDto> GetById(int id)
        {
            TEntity entity = await Db.GetByIdAsync<TEntity>(id);
            return Mapper.Map<TDto>(entity);
        }

        public async Task<TDto> Update(TDto dto)
        {
            TEntity entity = Mapper.Map<TEntity>(dto);
            TEntity newEntity = await Db.UpdateAsync(entity);
            return Mapper.Map<TDto>(newEntity);
        }

        public async Task<IEnumerable<TDto>> GetAll()
        {
            IEnumerable<TEntity> entityies = await Db.GetAllAsync<TEntity>();
            return entityies.Select(e => Mapper.Map<TDto>(e));
        }

        public async Task<bool> Delete(int id)
        {
            return await Db.DeleteAsync<TEntity>(id);
        }
    }
}
