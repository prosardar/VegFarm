using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.BL.Service;
using VerFarm.Kernel.Model.DTO;

namespace VerFarm.Kernel.BL.Implimantation
{
    public class EmployeeService : IService<EmployeeDTO>
    {
        private Repository<Employee, EmployeeDTO> _employeeRep;

        public async Task<EmployeeDTO> Add(EmployeeDTO employee)
        {
            return await _employeeRep.Add(employee);
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> Update(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }
    }
}
