namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedArticlesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false, maxLength: 1000),
                        Title = c.String(),
                        Description = c.String(maxLength: 4000),
                        Url = c.String(maxLength: 4000),
                        PublicationDate = c.DateTime(nullable: false),
                        Content = c.String(nullable: false),
                        AssetType = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Articles",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "IsDeleted",
                        new Dictionary<string, object>
                        {
                            { "Default", "0" },
                        }
                    },
                });
        }
    }
}
