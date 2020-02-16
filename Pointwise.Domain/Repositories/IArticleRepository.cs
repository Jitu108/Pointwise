﻿using Pointwise.Domain.Interfaces;
using System.Collections.Generic;
using Pointwise.Domain.Enums;
using Pointwise.Domain.Models;

namespace Pointwise.Domain.Repositories
{
    public interface IArticleRepository : IRepository<IArticle, Article>
    {
        IEnumerable<IArticle> GetAllArticles();
        IEnumerable<IArticle> GetArticlesByAuthor(string author);
        IEnumerable<IArticle> GetArticleByTitle(string titleString);
        IEnumerable<IArticle> GetArticleByDescription(string descString);
        IEnumerable<IArticle> GetArticleByContent(string contentString);
        IEnumerable<IArticle> GetArticleBySource(int sourceId);
        IEnumerable<IArticle> GetArticleByCategory(int categoryId);
        IEnumerable<IArticle> GetArticleByAssetType(ArticleAssociatedAssetType assetType);

    }
}