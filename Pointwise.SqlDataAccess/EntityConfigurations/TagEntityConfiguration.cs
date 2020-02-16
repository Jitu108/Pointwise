using Pointwise.Domain.ValidationRules;
using Pointwise.SqlDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointwise.SqlDataAccess.EntityConfigurations
{
    public class TagEntityConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagEntityConfiguration()
        {
            // Table Name
            ToTable("Tags");

            // PK
            HasKey(x => x.Id);

            // Property Configurations

            if (TagValidator.Name.IsRequired)
            {
                Property(x => x.Name).IsRequired();
            }

            Property(x => x.Name)
                .HasMaxLength(TagValidator.Name.MaxLength);


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
