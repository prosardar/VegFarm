namespace VerFarm.Kernel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someelseattr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeTransfer", "EmployeeId", "dbo.Employee");
            AddForeignKey("dbo.EmployeeTransfer", "EmployeeId", "dbo.Employee", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeTransfer", "EmployeeId", "dbo.Employee");
            AddForeignKey("dbo.EmployeeTransfer", "EmployeeId", "dbo.Employee", "Id");
        }
    }
}
