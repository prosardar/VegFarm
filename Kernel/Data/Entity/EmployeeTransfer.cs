namespace VerFarm.Kernel.Data.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeTransfer")]
    public partial class EmployeeTransfer : BaseEntity
    {
        public int EmployeeId { get; set; }

        public int ToDepartmentId { get; set; }

        public bool Confirm { get; set; }

        public DateTime ConfirmDate { get; set; }

        public virtual CatalogDepartment CatalogDepartment { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
