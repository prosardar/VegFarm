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
    public class EmployeeService : IEmployeeService
    {
        private Repository<Employee, EmployeeDTO> _employeeRep;
        private Repository<CatalogDepartment, CatalogDepartmentDTO> _departmentRep;
        private Repository<EmployeeTransfer, EmployeeTransferDTO> _transferRep;

        public EmployeeService(IDbContext context, IMapper mapper)
        {
            _employeeRep = new Repository<Employee, EmployeeDTO>(context, mapper);
            _departmentRep = new Repository<CatalogDepartment, CatalogDepartmentDTO>(context, mapper);
            _transferRep = new Repository<EmployeeTransfer, EmployeeTransferDTO>(context, mapper);
        }

        #region CRUD Interface Implementations

        public async Task<IBaseDTO> Add(IBaseDTO dto)
        {
            EmployeeDTO newEmp = (EmployeeDTO)dto;
            if (newEmp.QualificationId > (int)QualificationNames.Инженер)
            {
                newEmp.SetError("Новый сотрудник не должен быть выше по квалификации, чем 'Инженер'.");
                return newEmp;
            }
            if (newEmp.Probation == false)
            {
                newEmp.SetError("Новый сотрудник должен быть на испытательном сроке.");
                return newEmp;
            }
            if (new int[] { 1, 2, 3 }.Contains(newEmp.ProbationDays) == false)
            {
                newEmp.SetError("У нового сотрудника должен быть задан исп. срок (1, 2 или 3 месяца)!");
                return newEmp;
            }
            EmployeeTransferDTO transfer = new EmployeeTransferDTO()
            {
                Confirm = true,
                ConfirmDate = DateTime.Now,
                EmployeeId = newEmp.Id,
                ToDepartmentId = newEmp.DepartmentId
            };
            await _transferRep.Add(transfer);
            return await _employeeRep.Add(dto);
        }

        public async Task<bool> Delete(int id)
        {            
            return await _employeeRep.Delete(id);
        }

        public async Task<IEnumerable<IBaseDTO>> GetAll()
        {
            return await _employeeRep.GetAll();
        }

        public async Task<IBaseDTO> GetById(int id)
        {
            return await _employeeRep.GetById(id);
        }

        public async Task<IBaseDTO> Update(IBaseDTO newDto)
        {
            EmployeeDTO newEmp = (EmployeeDTO)newDto;
            EmployeeDTO oldEmp = (EmployeeDTO)await _employeeRep.GetById(newDto.Id);
            if (oldEmp.DepartmentId != newEmp.DepartmentId)
            {
                if (newEmp.Probation)
                {
                    newDto.SetError("Нельзя переводить сотрудника на исп. сроке!");
                    return newEmp;
                }
                var department = (CatalogDepartmentDTO)await _departmentRep.GetById(newEmp.DepartmentId);
                if (department.IsFull() && newEmp.TransferHeadAssent == false)
                {
                    newDto.SetError("Нельзя переводить сотрудника в отдел с максимальным кол-ом сотрудников, без согласия руководства!");
                    return newEmp;
                }
                EmployeeTransferDTO transfer = new EmployeeTransferDTO()
                {
                    Confirm = true,
                    ConfirmDate = DateTime.Now,
                    EmployeeId = newEmp.Id,
                    ToDepartmentId = newEmp.DepartmentId
                };
                await _transferRep.Add(transfer);
            }
            return await _employeeRep.Update(newDto);
        }

        #endregion
    }
}
