namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEntityUserRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRoles");
        }
    }
}