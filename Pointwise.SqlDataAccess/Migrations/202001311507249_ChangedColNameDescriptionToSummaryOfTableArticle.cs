namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedColNameDescriptionToSummaryOfTableArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Summary", c => c.String(maxLength: 4000));
            DropColumn("dbo.Articles", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Description", c => c.String(maxLength: 4000));
            DropColumn("dbo.Articles", "Summary");
        }
    }
}
