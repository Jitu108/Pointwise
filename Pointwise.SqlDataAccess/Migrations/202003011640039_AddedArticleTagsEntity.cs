namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedArticleTagsEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleTags",
                c => new
                    {
                        ArticleId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.TagId })
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.TagId);
            
            DropColumn("dbo.Articles", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Url", c => c.String(maxLength: 4000));
            DropForeignKey("dbo.ArticleTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.ArticleTags", "ArticleId", "dbo.Articles");
            DropIndex("dbo.ArticleTags", new[] { "TagId" });
            DropIndex("dbo.ArticleTags", new[] { "ArticleId" });
            DropTable("dbo.ArticleTags");
        }
    }
}
