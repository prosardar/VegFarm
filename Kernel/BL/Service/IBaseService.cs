using System.Collections.Generic;
using System.Threading.Tasks;
using VerFarm.Kernel.Model.DTO;

namespace VerFarm.Kernel.BL.Service
{
    public interface IBaseService
    {
        Task<IEnumerable<IBaseDTO>> GetAll();

        Task<IBaseDTO> GetById(int id);

        Task<IBaseDTO> Add(IBaseDTO dto);

        Task<IBaseDTO> Update(IBaseDTO dto);

        Task<bool> Delete(int id);
    }
}