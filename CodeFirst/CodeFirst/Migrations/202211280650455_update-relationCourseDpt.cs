namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updaterelationCourseDpt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "DptId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "DptId");
            AddForeignKey("dbo.Courses", "DptId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "DptId", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "DptId" });
            DropColumn("dbo.Courses", "DptId");
        }
    }
}
