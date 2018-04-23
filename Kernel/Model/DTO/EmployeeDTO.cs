using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VerFarm.Kernel.Model.DTO
{
    [Serializable]
    [DataContract]
    public class EmployeeDTO : BaseDTO
    {          
        public string FName { get; set; }

        public string IName { get; set; }
    
        public string OName { get; set; }
    
        public string Fio { get; set; }

        public bool Probation { get; set; }

        public int QualificationId { get; set; }

        public int DepartmentId { get; set; }

        public virtual CatalogDepartmentDTO CatalogDepartment { get; set; }

        public virtual CatalogQualificationDTO CatalogQualification { get; set; }

        public virtual ICollection<EmployeeTransferDTO> EmployeeTransfer { get; set; }
    }
}
