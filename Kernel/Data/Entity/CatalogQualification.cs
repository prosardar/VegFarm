namespace VerFarm.Kernel.Data.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CatalogQualification")]
    public partial class CatalogQualification : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Qualification { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }

        public CatalogQualification()
        {
            Employee = new HashSet<Employee>();
        }
    }
}
