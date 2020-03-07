namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSourceAndCategoryPropertyToArticleEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "SourceId", c => c.Int());
            AddColumn("dbo.Articles", "CategoryId", c => c.Int());
            AlterColumn("dbo.Articles", "Author", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Articles", "Content", c => c.String());
            CreateIndex("dbo.Articles", "SourceId");
            CreateIndex("dbo.Articles", "CategoryId");
            AddForeignKey("dbo.Articles", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Articles", "SourceId", "dbo.Sources", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "SourceId", "dbo.Sources");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropIndex("dbo.Articles", new[] { "SourceId" });
            AlterColumn("dbo.Articles", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "Author", c => c.String(nullable: false, maxLength: 1000));
            DropColumn("dbo.Articles", "CategoryId");
            DropColumn("dbo.Articles", "SourceId");
        }
    }
}
