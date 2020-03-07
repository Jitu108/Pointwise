namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTypeData2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO UserTypes (Name, IsDeleted, CreatedOn) 
                SELECT 'Admin', 0, GETDATE() 
                UNION ALL 
                SELECT 'Author', 0, GETDATE() 
                UNION ALL 
                SELECT 'Registred User', 0, GETDATE() 
                UNION ALL 
                SELECT 'Anonymous User', 0, GETDATE()");
        }
        
        public override void Down()
        {
        }
    }
}
