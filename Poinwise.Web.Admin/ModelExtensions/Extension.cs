using Pointwise.Domain.Models;
using Pointwise.Web.Admin.ViewModels;

namespace Pointwise.Web.Admin.ModelExtensions
{
    public static class Extension
    {
        
        public static CategoryViewModel ToViewModel(this Category entity)
        {
            return new CategoryViewModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
        
        public static SourceViewModel ToViewModel(this Source entity)
        {
            return new SourceViewModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        /*
        public static Article ToPersistentEntity(this Domain.Models.Article entity)
        {
            return new Article
            {
                Id = entity.Id,
                Author = entity.Author,
                Title = entity.Title,
                Description = entity.Description,
                Url = entity.Description,
                PublicationDate = entity.PublicationDate,
                Content = entity.Content,
                Source = entity.Source,
                Category = entity.Category,
                AssetType = entity.AssetType
            };
        }
        */
    }
}