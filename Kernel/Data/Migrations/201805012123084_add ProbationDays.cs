namespace VerFarm.Kernel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProbationDays : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "ProbationDays", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "ProbationDays");
        }
    }
}
