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
        [DataMember]
        public string FName { get; set; }

        [DataMember]
        public string IName { get; set; }

        [DataMember]
        public string OName { get; set; }

        [DataMember]
        public string Fio { get { return $"{FName} {IName} {OName}"; } }

        [DataMember]
        public bool Probation { get; set; }

        [DataMember]
        public int ProbationDays { get; set; }

        [DataMember]
        public int QualificationId { get; set; }

        [DataMember]
        public int DepartmentId { get; set; }

        [DataMember]
        public CatalogDepartmentDTO CatalogDepartment { get; set; }
                
        [DataMember]
        public CatalogQualificationDTO CatalogQualification { get; set; }

        [DataMember]
        public ICollection<EmployeeTransferDTO> EmployeeTransfer { get; set; }        
    }
}
