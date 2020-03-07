using Pointwise.Domain.Enums;
using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Pointwise.API.Admin.Models
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }
        public string ArticleAuthor { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleSummary { get; set; }
        // Article Url
        public string ArticleUrl { get; set; }
        public DateTime? ArticlePublicationDate { get; set; }
        public string ArticleContent { get; set; }
        public string ArticleSynopsis { get; set; }
        public int ArticleSourceId { get; set; }
        public string ArticleSource { get; set; }

        public int ArticleCategoryId { get; set; }
        public string ArticleCategory { get; set; }
        public string ArticleAssetType { get; set; }
        public IList<string> ArticleTags { get; set; }
        public bool ArticleIsDeleted { get; set; }


        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string ImageContentType { get; set; }
        public string ImageData { get; set; }
        public string ImageExtension { get; set; }
        public string ImageSavedTo { get; set; }

        public static Article ToModel(ArticleDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var article = new Article
            {
                Id = dto.ArticleId,
                Author = dto.ArticleAuthor,
                Title = dto.ArticleTitle,
                Summary = dto.ArticleSummary,
                Url = dto.ArticleUrl,
                PublicationDate = dto.ArticlePublicationDate,
                Content = dto.ArticleContent,
                Synopsis = dto.ArticleSynopsis,
                Source = dto.ArticleSourceId != 0 ? new Source { Id = dto.ArticleSourceId, Name = dto.ArticleSource } : null,
                Category = dto.ArticleCategoryId != 0 ? new Category { Id = dto.ArticleCategoryId, Name = dto.ArticleCategory } : null,
                AssetType = dto.ArticleAssetType != null ? (ArticleAssociatedAssetType)Enum.Parse(typeof(ArticleAssociatedAssetType), dto.ArticleAssetType) : ArticleAssociatedAssetType.None,
                Tags = dto.ArticleTags != null ? dto.ArticleTags.Select(x => new Tag { Name = x }).Cast<ITag>().ToList() : new List<ITag>(),
                IsDeleted = dto.ArticleIsDeleted
            };

            if(dto.ImageName != null)
            {
                article.Images = new List<IImage>();
                var image = new Image
                {
                    Id = dto.ImageId,
                    Name = dto.ImageName,
                    Path = dto.ImagePath,
                    ContentType = dto.ImageContentType,
                    Data = dto.ImageData != null ? Encoding.ASCII.GetBytes(dto.ImageData) : Array.Empty<byte>(),
                    Extension = dto.ImageExtension != null ? (Extension)Enum.Parse(typeof(Extension), dto.ImageExtension) : Extension.None,
                    SavedTo = dto.ImageSavedTo != null ? (ImageSaveTo)Enum.Parse(typeof(ImageSaveTo), dto.ImageSavedTo) : ImageSaveTo.None,
                };
                article.Images.Add(image);
            }
            else
            {
                article.Images = new List<IImage>();
            }
            return article;
        }

        public static ArticleDTO ToDTO(Article article)
        {
            if (article == null) throw new ArgumentNullException(nameof(article));

            var articleDTO = new ArticleDTO
            {
                ArticleId = article.Id,
                ArticleAuthor = article.Author,
                ArticleTitle = article.Title,
                ArticleSummary = article.Summary,

                ArticleUrl = article.Url,
                ArticlePublicationDate = article.PublicationDate,
                ArticleContent = article.Content,
                ArticleSynopsis = article.Synopsis,
                ArticleAssetType = Enum.GetName(article.AssetType.GetType(), article.AssetType),
                ArticleTags = article.Tags.Select(x => x.Name).ToList(),
                ArticleIsDeleted = article.IsDeleted
            };

            if(article.Source != null)
            {
                articleDTO.ArticleSourceId = article.Source.Id;
                articleDTO.ArticleSource = article.Source.Name;
            }

            if(article.Category != null)
            {
                articleDTO.ArticleCategoryId = article.Category.Id;
                articleDTO.ArticleCategory = article.Category.Name;
            }

            if(article.Images != null && article.Images.Count > 0)
            {
                var image = article.Images.FirstOrDefault();
                articleDTO.ImageId = image.Id;
                articleDTO.ImageName = image.Name;
                articleDTO.ImagePath = image.Path;
                articleDTO.ImageContentType = image.ContentType;
                articleDTO.ImageData = System.Text.Encoding.UTF8.GetString(image.Data);
                articleDTO.ImageExtension = Enum.GetName(image.Extension.GetType(), image.Extension);
            }

            return articleDTO;
        }
    }
}