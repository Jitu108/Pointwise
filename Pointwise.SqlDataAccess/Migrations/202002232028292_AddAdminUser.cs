namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [Users]
                ([FirstName]
                ,[UserTypeId]
                ,[UserNameType]
                ,[UserName]
                ,[Password]
                ,[IsBlocked]
                ,[IsDeleted]
                ,[CreatedOn])

                SELECT
                'Admin',
                1,
                1,
                'admin@pointwise.com',
                'admin@123',
                0,
                0,
                GETDATE()

            ");
        }
        
        public override void Down()
        {
        }
    }
}
