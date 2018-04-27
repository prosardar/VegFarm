namespace VerFarm.Kernel.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChangeLog")]
    public partial class ChangeLog : BaseEntity
    {
        public int ActionId { get; set; }

        public string NewValue { get; set; }

        public string OldValue { get; set; }

        [Required]
        public string EntityName { get; set; }

        [Required]
        public string PrimaryKeyValue { get; set; }
        
        public string PropertyName { get; set; }

        public string UserName { get; set; }

        public DateTime? DateChanged { get; set; }
    }
}
