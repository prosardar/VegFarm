using System.Collections.Generic;
using System.Threading.Tasks;
using VerFarm.Kernel.Model.DTO;

namespace VerFarm.Kernel.BL.Service
{
    public interface IService<TDto> where TDto : DTOBase
    {
        Task<IEnumerable<TDto>> GetAll();

        Task<TDto> GetById(int id);

        Task<TDto> Add(TDto dto);

        Task<TDto> Update(TDto dto);

        Task<bool> Delete(int id);
    }
}