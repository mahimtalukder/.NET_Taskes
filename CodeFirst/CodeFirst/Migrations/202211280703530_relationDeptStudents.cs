namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationDeptStudents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "DeptId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Department_Id", c => c.Int());
            CreateIndex("dbo.Students", "Department_Id");
            AddForeignKey("dbo.Students", "Department_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "Department_Id" });
            DropColumn("dbo.Students", "Department_Id");
            DropColumn("dbo.Students", "DeptId");
        }
    }
}
