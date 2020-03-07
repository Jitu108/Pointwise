using Pointwise.SqlDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointwise.SqlDataAccess.EntityConfigurations
{
    public class ArticleEntityCofiguration : EntityTypeConfiguration<Article>
    {
        public ArticleEntityCofiguration()
        {
            // Table Name
            ToTable("Articles");

            // PK
            HasKey(x => x.Id);

            // Property Configurations
            Property(x => x.Author)
                //.IsRequired()
                .HasMaxLength(1000);

            Property(x => x.Summary)
                .HasMaxLength(4000);

            //Property(x => x.PublicationDate)
                //.IsRequired();

            //Property(x => x.Content)
                //.IsRequired();

            //Property(x => x.AssetType)
                //.IsRequired();

            HasMany(x => x.SqlTags)
                .WithMany(x => x.SqlArticles)
                .Map(m =>
                {
                    m.MapLeftKey("ArticleId");
                    m.MapRightKey("TagId");
                    m.ToTable("ArticleTags");
                });

            HasMany(x => x.SqlImages)
                .WithRequired(x => x.Article)
                .HasForeignKey(x => x.ArticleId);

            HasOptional(x => x.SqlCategory)
                .WithMany(x => x.SqlArticles)
                .HasForeignKey(x => x.CategoryId);

            HasOptional(x => x.SqlSource)
                .WithMany(x => x.SqlArticles)
                .HasForeignKey(x => x.SourceId);

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
