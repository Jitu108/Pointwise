namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeExtensionAndSaveToNullableOfImageEntity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "Extension", c => c.Int());
            AlterColumn("dbo.Images", "SavedTo", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "SavedTo", c => c.Int(nullable: false));
            AlterColumn("dbo.Images", "Extension", c => c.Int(nullable: false));
        }
    }
}
