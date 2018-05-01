namespace VerFarm.Kernel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CatalogDepartment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                        EmployeeCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 100, unicode: false),
                        IName = c.String(nullable: false, maxLength: 100, unicode: false),
                        OName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Probation = c.Boolean(nullable: false),
                        QualificationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CatalogQualification", t => t.QualificationId)
                .ForeignKey("dbo.CatalogDepartment", t => t.DepartmentId)
                .Index(t => t.QualificationId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.CatalogQualification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qualification = c.String(nullable: false, maxLength: 50, unicode: false),
                        Rang = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeTransfer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ToDepartmentId = c.Int(nullable: false),
                        Confirm = c.Boolean(nullable: false),
                        ConfirmDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.CatalogDepartment", t => t.ToDepartmentId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ToDepartmentId);
            
            CreateTable(
                "dbo.ChangeLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActionId = c.Int(nullable: false),
                        NewValue = c.String(unicode: false),
                        OldValue = c.String(unicode: false),
                        EntityName = c.String(nullable: false, unicode: false),
                        PrimaryKeyValue = c.String(nullable: false, unicode: false),
                        PropertyName = c.String(),
                        UserName = c.String(),
                        DateChanged = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeTransfer", "ToDepartmentId", "dbo.CatalogDepartment");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.CatalogDepartment");
            DropForeignKey("dbo.EmployeeTransfer", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "QualificationId", "dbo.CatalogQualification");
            DropIndex("dbo.EmployeeTransfer", new[] { "ToDepartmentId" });
            DropIndex("dbo.EmployeeTransfer", new[] { "EmployeeId" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Employee", new[] { "QualificationId" });
            DropTable("dbo.ChangeLog");
            DropTable("dbo.EmployeeTransfer");
            DropTable("dbo.CatalogQualification");
            DropTable("dbo.Employee");
            DropTable("dbo.CatalogDepartment");
        }
    }
}
