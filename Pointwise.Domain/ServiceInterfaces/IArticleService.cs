using System.Collections.Generic;
using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Enums;
using System;

namespace Pointwise.Domain.ServiceInterfaces
{
    public interface IArticleService
    {
        IEnumerable<IArticle> GetAllArticles();
        IArticle GetById(int id);
        IEnumerable<IArticle> GetArticlesByAuthor(string author);
        IEnumerable<IArticle> GetArticleByTitle(string titleString);
        IEnumerable<IArticle> GetArticleByDescription(string descString);
        IEnumerable<IArticle> GetArticleByContent(string contentString);
        IEnumerable<IArticle> GetArticleBySource(int sourceId);
        IEnumerable<IArticle> GetArticleByCategory(int categoryId);
        IEnumerable<IArticle> GetArticleByAssetType(ArticleAssociatedAssetType AssetType);

        IArticle Add(Models.Article entity);

        IEnumerable<IArticle> AddRange(IEnumerable<Models.Article> entities);

        bool Delete(int id);

        bool DeleteRange(IEnumerable<Models.Article> entities);
        bool SoftDelete(int id);
        bool UndoSoftDelete(int id);
        bool SoftDeleteRange(IEnumerable<Models.Article> entities);

        IArticle Update(Models.Article entity);
    }
}
