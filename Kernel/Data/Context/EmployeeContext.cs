using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.Data.Entity;

namespace VerFarm.Kernel.Data.Context
{
    public class EmployeeContext : AuditDbContext
    {
        public virtual DbSet<CatalogDepartment> CatalogDepartment { get; set; }
        public virtual DbSet<CatalogQualification> CatalogQualification { get; set; }        
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeTransfer> EmployeeTransfer { get; set; }

        public EmployeeContext()
           : base("name=EmployeeContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CatalogDepartment>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CatalogDepartment>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.CatalogDepartment)
                .HasForeignKey(e => e.DepartmentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CatalogDepartment>()
                .HasMany(e => e.EmployeeTransfer)
                .WithRequired(e => e.CatalogDepartment)
                .HasForeignKey(e => e.ToDepartmentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CatalogQualification>()
                .Property(e => e.Qualification)
                .IsUnicode(false);

            modelBuilder.Entity<CatalogQualification>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.CatalogQualification)
                .HasForeignKey(e => e.QualificationId)
                .WillCascadeOnDelete(false);         

            modelBuilder.Entity<Employee>()
                .Property(e => e.FName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.IName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.OName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Fio)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeTransfer)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);            
        }
    }
}
