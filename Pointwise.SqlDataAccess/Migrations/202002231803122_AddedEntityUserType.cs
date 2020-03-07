namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEntityUserType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTypes",
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
            DropTable("dbo.UserTypes");
        }
    }
}
