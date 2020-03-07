namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameUserRolesTableToRoles : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRoles", newName: "Roles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Roles", newName: "UserRoles");
        }
    }
}
