using Pointwise.Domain.ValidationRules;
using Pointwise.SqlDataAccess.Models;
using System;
using System.Data.Entity.ModelConfiguration;

namespace Pointwise.SqlDataAccess.EntityConfigurations
{
    public class SourceEntityConfiguration : EntityTypeConfiguration<Source>
    {
        public SourceEntityConfiguration()
        {
            // Table Name
            ToTable("Sources");

            // PK
            HasKey(x => x.Id);

            // Property Configurations
            if (SourceValidator.Name.IsRequired)
            {
                Property(x => x.Name)
                    .IsRequired();
            }

            Property(x => x.Name)
                .HasMaxLength(SourceValidator.Name.MaxLength);


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
