namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedUserTypeAndUserRoleEntities : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserRoles", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserRoles", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AlterColumn("dbo.UserTypes", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserTypes", "IsDeleted", c => c.Boolean(nullable: false,
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
            AlterColumn("dbo.UserTypes", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: "0", newValue: null)
                    },
                }));
            AlterColumn("dbo.UserTypes", "Name", c => c.String());
            AlterColumn("dbo.UserRoles", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: "0", newValue: null)
                    },
                }));
            AlterColumn("dbo.UserRoles", "Name", c => c.String());
        }
    }
}
