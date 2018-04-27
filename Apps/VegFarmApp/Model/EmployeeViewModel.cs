using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Model
{
    public class EmployeeViewModel : BaseViewModel<EmployeeDTO>
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

        public string FName
        {
            get => Dto.FName;
            set
            {
                string name = Dto.FName;
                SetProperty(ref name, value);
            }
        }

        public string IName
        {
            get => Dto.IName;
            set
            {
                string name = Dto.IName;
                SetProperty(ref name, value);
            }
        }

        public string OName
        {
            get => Dto.OName;
            set
            {
                string name = Dto.OName;
                SetProperty(ref name, value);
            }
        }

        public string Fio
        {
            get => Dto.Fio;
        }

        public bool Probation
        {
            get => Dto.Probation;
            set
            {
                bool probation = Dto.Probation;
                SetProperty(ref probation, value);
            }
        }

        public int QualificationId
        {
            get => Dto.QualificationId;
            set
            {
                int qualificationId = Dto.QualificationId;
                SetProperty(ref qualificationId, value);
            }
        }

        public int DepartmentId
        {
            get => Dto.DepartmentId;
            set
            {
                int departmentId = Dto.DepartmentId;
                SetProperty(ref departmentId, value);
            }
        }

        public EmployeeViewModel(EmployeeDTO dto) : base(dto)
        {
        }

        public EmployeeViewModel() : this(new EmployeeDTO())
        {

        }
    }
}
