using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerFarm.Kernel.Model.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();

        Task<EmployeeDTO> GetEmployeeAsync(int id);

        Task<int> DeleteAsync(int id);
    }
}
