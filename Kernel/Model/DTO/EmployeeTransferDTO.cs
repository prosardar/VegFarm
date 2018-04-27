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
        [DataMember]
        public int EmployeeId { get; set; }

        [DataMember]
        public int ToDepartmentId { get; set; }

        [DataMember]
        public bool Confirm { get; set; }

        [DataMember]
        public DateTime ConfirmDate { get; set; }

        [DataMember]
        public CatalogDepartmentDTO CatalogDepartment { get; set; }

        [DataMember]
        public EmployeeDTO Employee { get; set; }
    }
}
