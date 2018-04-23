using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.BL.Service;
using VerFarm.Kernel.Data.Entity;
using VerFarm.Kernel.Model.DTO;

namespace VerFarm.Kernel.BL.Implemantation
{
    public class EmployeeService : IService<EmployeeDTO>
    {
        private Repository<Employee, EmployeeDTO> _employeeRep;

        public EmployeeService(IDbContext context, IMapper mapper)
        {
            _employeeRep = new Repository<Employee, EmployeeDTO>(context, mapper);
        }

        #region CRUD Interface Implementations

        public async Task<EmployeeDTO> Add(EmployeeDTO employee)
        {
            return await _employeeRep.Add(employee);
        }

        public async Task<bool> Delete(int id)
        {
            return await _employeeRep.Delete(id);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            return await _employeeRep.GetAll();
        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            return await _employeeRep.GetById(id);
        }

        public async Task<EmployeeDTO> Update(EmployeeDTO employee)
        {
            return await _employeeRep.Update(employee);
        }

        #endregion
    }
}
