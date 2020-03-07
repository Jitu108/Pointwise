namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        ContentType = c.String(),
                        Data = c.Binary(),
                        Extension = c.Int(nullable: false),
                        SavedTo = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Images", new[] { "ArticleId" });
            DropTable("dbo.Images");
        }
    }
}
