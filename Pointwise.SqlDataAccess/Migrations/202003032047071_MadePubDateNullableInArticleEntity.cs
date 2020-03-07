namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadePubDateNullableInArticleEntity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "PublicationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "PublicationDate", c => c.DateTime(nullable: false));
        }
    }
}
