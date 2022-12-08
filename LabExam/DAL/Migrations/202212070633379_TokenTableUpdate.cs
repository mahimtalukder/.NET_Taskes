namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenTableUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tokens", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tokens", "Type", c => c.Int(nullable: false));
        }
    }
}
