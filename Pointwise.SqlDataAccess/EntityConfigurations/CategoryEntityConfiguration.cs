using Pointwise.Domain.ValidationRules;
using Pointwise.SqlDataAccess.Models;
using System;
using System.Data.Entity.ModelConfiguration;

namespace Pointwise.SqlDataAccess.EntityConfigurations
{
    class CategoryEntityConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryEntityConfiguration()
        {
            // Table Name
            ToTable("Category");

            // PK
            HasKey(x => x.Id);

            // Property Configurations

            if (CategoryValidator.Name.IsRequired)
            {
                Property(x => x.Name).IsRequired();
            }

            Property(x => x.Name)
                .HasMaxLength(CategoryValidator.Name.MaxLength);
            

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
