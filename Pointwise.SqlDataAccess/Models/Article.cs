using Pointwise.Domain.Enums;
using Pointwise.Domain.Interfaces;
using Pointwise.SqlDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pointwise.SqlDataAccess.Models
{
    public partial class Article : Domain.Models.BaseEntity, IArticle
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string Content { get; set; }
        public string Synopsis { get; set; }

        public Source SqlSource { get; set; }
        public ISource Source { 
            get { return SqlSource as ISource; } 
            set { SqlSource = value as Source; } 
        }
        public int? SourceId { get; set; }

        public Category SqlCategory { get; set; }
        public ICategory Category {
            get { return SqlCategory as ICategory; }
            set { SqlCategory = value as Category; }
        }
        public int? CategoryId { get; set; }
        public ArticleAssociatedAssetType AssetType { get; set; }
        public IList<Tag> SqlTags { get; set; }

        public IList<ITag> Tags
        {
            get { return SqlTags.Cast<ITag>().ToList(); }
            set { SqlTags = value.Select(x => x as Tag).ToList(); }
        }

        public IList<Image> SqlImages { get; set; }

        public IList<IImage> Images
        {
            get { return SqlImages.Cast<IImage>().ToList(); }
            set { SqlImages = value.Select(x => x as Image).ToList(); }
        }
    }

    public partial class Article : IConvert<Domain.Models.Article>
    {
        public Domain.Models.Article ToDomainEntity()
        {
            return new Domain.Models.Article
            {
                Id = this.Id,
                Author = this.Author,
                Title = this.Title,
                Summary = this.Summary,
                Url = this.Url,
                PublicationDate = this.PublicationDate,
                Content = this.Content,
                Synopsis = this.Synopsis,
                Source = this.SqlSource != null? this.SqlSource as ISource : new Source(),
                Category = this.SqlCategory != null ? this.SqlCategory as ICategory : new Category(),
                AssetType = this.AssetType,
                Tags = this.SqlTags != null ? this.SqlTags.Cast<ITag>().ToList() : new List<ITag>(),
                Images = this.SqlTags != null ? this.SqlImages.Cast<IImage>().ToList(): new List<IImage>(),
                CreatedOn = this.CreatedOn,
                LastModifiedOn = this.LastModifiedOn,
                IsDeleted = this.IsDeleted
            };
        }
    }
}
