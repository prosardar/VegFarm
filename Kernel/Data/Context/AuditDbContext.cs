using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VerFarm.Kernel.Data.Audit;
using VerFarm.Kernel.Data.Entity;

namespace VerFarm.Kernel.Data.Context
{
    public class AuditDbContext : DbContext
    {
        public virtual DbSet<ChangeLog> ChangeLog { get; set; }

        public AuditDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public override int SaveChanges()
        {
            SaveWithAudit();
            return base.SaveChanges();
        }

        public async override Task<int> SaveChangesAsync()
        {
            SaveWithAudit();
            return await base.SaveChangesAsync();
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            SaveWithAudit();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void SaveWithAudit()
        {
            var auditFactory = new AuditTrailFactory(this);
            var entityList = ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified
                || (p.Entity is ChangeLog) == false || p.Entity != null);

            entityList.ToList().ForEach(entity =>
            {
                ChangeLog audit = auditFactory.GetAudit(entity);
                ChangeLog.Add(audit);
            });
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChangeLog>()
              .Property(e => e.NewValue)
              .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.OldValue)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.EntityName)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.PrimaryKeyValue)
                .IsUnicode(false);

            modelBuilder.Entity<ChangeLog>()
                .Property(e => e.PropertyName)
                .IsUnicode(false);            
        }
    }
}