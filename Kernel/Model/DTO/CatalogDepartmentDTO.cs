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
    public class CatalogDepartmentDTO : BaseDTO
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int EmployeeCount { get; set; }

        [DataMember]
        public ICollection<EmployeeDTO> Employee { get; set; }

        [DataMember]
        public ICollection<EmployeeTransferDTO> EmployeeTransfer { get; set; }
    }
}
