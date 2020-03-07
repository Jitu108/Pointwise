namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserRoleData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO UserRoles (Name, IsDeleted, CreatedOn) 
                SELECT 'User Administrator', 0, GETDATE()
                UNION ALL 
                SELECT 'Source Author', 0, GETDATE() 
                UNION ALL 
                SELECT 'Category Author', 0, GETDATE()
                UNION ALL 
                SELECT 'Article Author', 0, GETDATE() 
                UNION ALL 
                SELECT 'Tag Author', 0, GETDATE()
            ");
        }
        
        public override void Down()
        {
        }
    }
}
