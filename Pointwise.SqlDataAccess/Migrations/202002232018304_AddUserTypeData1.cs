namespace Pointwise.SqlDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTypeData1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"truncate table UserRoles");
        }
        
        public override void Down()
        {
        }
    }
}
