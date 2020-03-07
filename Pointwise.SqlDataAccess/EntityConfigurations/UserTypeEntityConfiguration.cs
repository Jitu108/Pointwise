using Pointwise.Domain.ValidationRules;
using Pointwise.SqlDataAccess.Models;
using System.Data.Entity.ModelConfiguration;

namespace Pointwise.SqlDataAccess.EntityConfigurations
{
    class UserTypeEntityConfiguration : EntityTypeConfiguration<SqlUserType>
    {
        public UserTypeEntityConfiguration()
        {
            // Table Name
            ToTable("UserTypes");

            // PK
            HasKey(x => x.Id);

            // Property Configurations

            if (UserTypeValidator.Name.IsRequired)
            {
                Property(x => x.Name).IsRequired();
            }

            Property(x => x.Name)
                .HasMaxLength(UserTypeValidator.Name.MaxLength);


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
