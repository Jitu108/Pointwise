namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEntityUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        MiddleName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        EmailAddress = c.String(maxLength: 256),
                        PhoneNumber = c.String(maxLength: 50),
                        UserTypeId = c.Int(nullable: false),
                        UserNameType = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        IsBlocked = c.Boolean(nullable: false),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropTable("dbo.Users",
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
