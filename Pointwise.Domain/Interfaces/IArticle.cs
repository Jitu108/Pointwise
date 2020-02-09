using System;
using Pointwise.Domain.Enums;

namespace Pointwise.Domain.Interfaces
{
    public interface IArticle : IBaseEntity
    {
        int Id { get; set; }
        string Author { get; set; }
        string Title { get; set; }
        string Summary { get; set; }
        string Url { get; set; }
        DateTime PublicationDate { get; set; }
        string Content { get; set; }
        ISource Source { get; set; }
        ICategory Category { get; set; }
        ArticleAssociatedAssetType AssetType { get; set; }
    }
}
