using Pointwise.Domain.ValidationRules;
using Pointwise.SqlDataAccess.Models;
using System.Data.Entity.ModelConfiguration;

namespace Pointwise.SqlDataAccess.EntityConfigurations
{
    class UserRoleEntityConfiguration : EntityTypeConfiguration<SqlUserRole>
    {
        public UserRoleEntityConfiguration()
        {
            // Table Name
            ToTable("Roles");

            // PK
            HasKey(x => x.Id);

            // Property Configurations

            if (UserRoleValidator.Name.IsRequired)
            {
                Property(x => x.Name).IsRequired();
            }

            Property(x => x.Name)
                .HasMaxLength(UserRoleValidator.Name.MaxLength);


            // Common Property Configurations
            Property(x => x.IsDeleted)
                .IsRequired()
                .HasColumnAnnotation("Default", 0);

            Property(x => x.CreatedOn)
                .IsRequired();

            Property(x => x.LastModifiedOn)
                .IsOptional();
        }
    }
}
