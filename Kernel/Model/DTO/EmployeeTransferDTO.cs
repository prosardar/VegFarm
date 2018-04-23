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
    public class EmployeeTransferDTO : BaseDTO
    {
        public int EmployeeId { get; set; }

        public int ToDepartmentId { get; set; }

        public bool Confirm { get; set; }

        public DateTime ConfirmDate { get; set; }

        public virtual CatalogDepartmentDTO CatalogDepartment { get; set; }

        public virtual EmployeeDTO Employee { get; set; }
    }
}
