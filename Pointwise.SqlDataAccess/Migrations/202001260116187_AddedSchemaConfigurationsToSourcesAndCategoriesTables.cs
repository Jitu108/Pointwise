namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSchemaConfigurationsToSourcesAndCategoriesTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false, maxLength: 2000));
            AlterColumn("dbo.Category", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AlterColumn("dbo.Sources", "Name", c => c.String(nullable: false, maxLength: 2000));
            AlterColumn("dbo.Sources", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sources", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: "0", newValue: null)
                    },
                }));
            AlterColumn("dbo.Sources", "Name", c => c.String());
            AlterColumn("dbo.Category", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: "0", newValue: null)
                    },
                }));
            AlterColumn("dbo.Category", "Name", c => c.String());
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
