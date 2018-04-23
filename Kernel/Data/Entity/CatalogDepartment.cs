namespace VerFarm.Kernel.Data.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CatalogDepartment")]
    public class CatalogDepartment : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public int EmployeeCount { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }

        public virtual ICollection<EmployeeTransfer> EmployeeTransfer { get; set; }

        public CatalogDepartment()
        {
            Employee = new HashSet<Employee>();
            EmployeeTransfer = new HashSet<EmployeeTransfer>();
        }
    }
}
