using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Model
{
    public class EmployeeTransferViewModel : BaseViewModel<EmployeeTransferDTO>
    {
        public int Id
        {
            get => Dto.Id;
            set
            {
                int id = Dto.Id;
                SetProperty(ref id, value);
            }
        }

        public DateTime ConfirmDate
        {
            get => Dto.ConfirmDate;
            set
            {
                DateTime date = Dto.ConfirmDate;
                SetProperty(ref date, value);
            }
        }

        public bool Confirm
        {
            get => Dto.Confirm;
            set
            {
                bool confirm = Dto.Confirm;
                SetProperty(ref confirm, value);
            }
        }

        public int EmployeeId
        {
            get => Dto.EmployeeId;
            set
            {
                int employeeId = Dto.EmployeeId;
                SetProperty(ref employeeId, value);
            }
        }

        public EmployeeDTO Employee
        {
            get => Dto.Employee;
            set
            {
                EmployeeDTO employee = Dto.Employee;
                SetProperty(ref employee, value);
            }
        }

        public int ToDepartmentId
        {
            get => Dto.ToDepartmentId;
            set
            {
                int toDepartmentId = Dto.ToDepartmentId;
                SetProperty(ref toDepartmentId, value);
            }
        }

        public CatalogDepartmentDTO CatalogDepartment
        {
            get => Dto.CatalogDepartment;
            set
            {
                CatalogDepartmentDTO department = Dto.CatalogDepartment;
                SetProperty(ref department, value);
            }
        }

        public EmployeeTransferViewModel(EmployeeTransferDTO dto) : base(dto)
        {
        }

        public EmployeeTransferViewModel() : this(new EmployeeTransferDTO())
        {

        }
    }
}
