namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTagEntityConfiguration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Category", newName: "Categories");
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tags", "IsDeleted", c => c.Boolean(nullable: false,
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
            AlterColumn("dbo.Tags", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: "0", newValue: null)
                    },
                }));
            AlterColumn("dbo.Tags", "Name", c => c.String());
            RenameTable(name: "dbo.Categories", newName: "Category");
        }
    }
}
