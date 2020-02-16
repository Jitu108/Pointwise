using Pointwise.SqlDataAccess.Models;

namespace Pointwise.SqlDataAccess.ModelExtensions
{
    public static class Extension
    {
        public static Category ToPersistentEntity(this Domain.Models.Category entity)
        {
            return new Category
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static Source ToPersistentEntity(this Domain.Models.Source entity)
        {
            return new Source
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static Article ToPersistentEntity(this Domain.Models.Article entity)
        {
            return new Article
            {
                Id = entity.Id,
                Author = entity.Author,
                Title = entity.Title,
                Summary = entity.Summary,
                Url = entity.Summary,
                PublicationDate = entity.PublicationDate,
                Content = entity.Content,
                Source = entity.Source,
                Category = entity.Category,
                AssetType = entity.AssetType
            };
        }
        public static Tag ToPersistentEntity(this Domain.Models.Tag entity)
        {
            return new Tag
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
