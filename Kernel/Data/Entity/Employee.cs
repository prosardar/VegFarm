namespace VerFarm.Kernel.Data.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FName { get; set; }

        [Required]
        [StringLength(100)]
        public string IName { get; set; }

        [Required]
        [StringLength(50)]
        public string OName { get; set; }

        public bool Probation { get; set; }

        public int ProbationDays { get; set; }

        public int QualificationId { get; set; }

        public int DepartmentId { get; set; }

        public virtual CatalogDepartment CatalogDepartment { get; set; }

        public virtual CatalogQualification CatalogQualification { get; set; }

        public virtual ICollection<EmployeeTransfer> EmployeeTransfer { get; set; }

        public Employee()
        {
            EmployeeTransfer = new HashSet<EmployeeTransfer>();
        }
    }
}
