namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUserEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "SourceId", c => c.Int());
            CreateIndex("dbo.Users", "SourceId");
            AddForeignKey("dbo.Users", "SourceId", "dbo.Sources", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "SourceId", "dbo.Sources");
            DropIndex("dbo.Users", new[] { "SourceId" });
            DropColumn("dbo.Users", "SourceId");
        }
    }
}
