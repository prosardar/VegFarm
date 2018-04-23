using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.Core.Service;
using VerFarm.Kernel.Model.DTO;

namespace VerFarm.Kernel.Core.Implimantation
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService()
        {

        }
     
        public Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> CreateAsync(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> UpdateAsync(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
