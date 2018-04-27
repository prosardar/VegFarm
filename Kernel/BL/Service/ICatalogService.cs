using System.Collections.Generic;
using System.Threading.Tasks;
using VerFarm.Kernel.Model.DTO;

namespace VerFarm.Kernel.BL.Service
{
    public interface ICatalogService<TDto> where TDto : IBaseDTO
    {
        Task<IEnumerable<TDto>> GetAll(string catalogName);

        Task<TDto> GetById(string catalogName, int id);

        Task<TDto> Add(string catalogName, TDto dto);

        Task<TDto> Update(string catalogName, TDto dto);

        Task<bool> Delete(string catalogName, int id);
    }
}