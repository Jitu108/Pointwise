namespace Pointwise.SqlDataAccess
{
    using Pointwise.SqlDataAccess.EntityConfigurations;
    using Pointwise.SqlDataAccess.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PointwiseSqlContext : DbContext
    {
        // Your context has been configured to use a 'PointwiseSqlContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Pointwise.SqlDataAccess.PointwiseSqlContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PointwiseSqlContext' 
        // connection string in the application configuration file.
        public PointwiseSqlContext()
            : base("name=PointwiseSqlContext")
        {
        }

        public PointwiseSqlContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ArticleEntityCofiguration());
            modelBuilder.Configurations.Add(new CategoryEntityConfiguration());
            modelBuilder.Configurations.Add(new SourceEntityConfiguration());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}