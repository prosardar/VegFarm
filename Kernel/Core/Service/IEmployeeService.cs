using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.Model.DTO;

namespace VerFarm.Kernel.Core.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllAsync();

        Task<EmployeeDTO> GetAsync(int id);

        Task<EmployeeDTO> CreateAsync(EmployeeDTO employee);

        Task<EmployeeDTO> UpdateAsync(EmployeeDTO employee);

        Task<int> DeleteAsync(int id);
    }
}
