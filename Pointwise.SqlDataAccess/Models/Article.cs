using Pointwise.Domain.Enums;
using Pointwise.Domain.Interfaces;
using Pointwise.SqlDataAccess.Interfaces;
using System;

namespace Pointwise.SqlDataAccess.Models
{
    public partial class Article : Domain.Models.BaseEntity, IArticle
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Content { get; set; }
        public ISource Source { get; set; }
        public ICategory Category { get; set; }
        public ArticleAssociatedAssetType AssetType { get; set; }
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
                Url = this.Summary,
                PublicationDate = this.PublicationDate,
                Content = this.Content,
                Source = this.Source,
                Category = this.Category,
                AssetType = this.AssetType,
                CreatedOn = this.CreatedOn,
                LastModifiedOn = this.LastModifiedOn,
                IsDeleted = this.IsDeleted
            };
        }

        //public static Article ToPersistenceEntity(IArticle entity)
        //{
        //    return new Article
        //    {
        //        Id = entity.Id,
        //        Author = entity.Author,
        //        Title = entity.Title,
        //        Description = entity.Description,
        //        Url = entity.Description,
        //        PublicationDate = entity.PublicationDate,
        //        Content = entity.Content,
        //        Source = entity.Source,
        //        Category = entity.Category,
        //        AssetType = entity.AssetType
        //    };
        //}
    }
}
