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
    public class CatalogService : ICatalogService<IBaseDTO>
    {
        private Dictionary<string, IBaseService> _repositories;

        public CatalogService(IDbContext context, IMapper mapper)
        {
            _repositories = new Dictionary<string, IBaseService>();

            // подобный способ хоть и уменьшает кол-во кода, не по идеи нехороший тем что, есть объединение generic интерфейсов
            // технически работает, но смысловая нагрузка специфичная. 
            _repositories.Add("employees", new Repository<Employee, EmployeeDTO>(context, mapper));
            _repositories.Add("departments", new Repository<CatalogDepartment, CatalogDepartmentDTO>(context, mapper));
            _repositories.Add("qualifications", new Repository<CatalogQualification, CatalogQualificationDTO>(context, mapper));            
        }

        #region CRUD Interface Implementations

        public async Task<IEnumerable<IBaseDTO>> GetAll(string catalogName)
        {
            return await _repositories[catalogName].GetAll();
        }

        public async Task<IBaseDTO> GetById(string catalogName, int id)
        {
            return await _repositories[catalogName].GetById(id);
        }

        public async Task<IBaseDTO> Add(string catalogName, IBaseDTO employee)
        {
            return await _repositories[catalogName].Add(employee);
        }

        public async Task<IBaseDTO> Update(string catalogName, IBaseDTO employee)
        {
            return await _repositories[catalogName].Update(employee);
        }

        public async Task<bool> Delete(string catalogName, int id)
        {
            return await _repositories[catalogName].Delete(id);
        }

        #endregion
    }
}
