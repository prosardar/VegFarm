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
        public string Name { get; set; }

        public int EmployeeCount { get; set; }
    }
}
