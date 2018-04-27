using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VerFarm.Kernel.Model.DTO
{
    [Serializable]
    [DataContract]
    public class CatalogQualificationDTO : BaseDTO
    {
        [DataMember]
        public string Qualification { get; set; }

        [DataMember]
        public int Rang { get; set; }

        [DataMember]
        public ICollection<EmployeeDTO> Employee { get; set; }
    }
}