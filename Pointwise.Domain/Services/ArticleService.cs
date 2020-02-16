using System;
using System.Collections.Generic;
using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Repositories;
using Pointwise.Domain.ServiceInterfaces;
using Pointwise.Domain.Enums;
using Pointwise.Domain.Models;

namespace Pointwise.Domain.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository repository;

        public ArticleService(IArticleRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            this.repository = repository;
        }

        public IEnumerable<IArticle> GetAllArticles()
        {
            return repository.GetAllArticles();
        }

        public IArticle GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<IArticle> GetArticlesByAuthor(string author)
        {
            return repository.GetArticlesByAuthor(author);
        }

        public IEnumerable<IArticle> GetArticleByTitle(string titleString)
        {
            return repository.GetArticleByTitle(titleString);
        }

        public IEnumerable<IArticle> GetArticleByDescription(string descString)
        {
            return repository.GetArticleByDescription(descString);
        }

        public IEnumerable<IArticle> GetArticleByContent(string contentString)
        {
            return repository.GetArticleByContent(contentString);
        }

        public IEnumerable<IArticle> GetArticleBySource(int sourceId)
        {
            return repository.GetArticleBySource(sourceId);
        }

        public IEnumerable<IArticle> GetArticleByCategory(int categoryId)
        {
            return repository.GetArticleByCategory(categoryId);
        }

        public IEnumerable<IArticle> GetArticleByAssetType(ArticleAssociatedAssetType assetType)
        {
            return repository.GetArticleByAssetType(assetType);
        }

        public IArticle Add(Article entity)
        {
            return repository.Add(entity);
        }

        public IEnumerable<IArticle> AddRange(IEnumerable<Article> entities)
        {
            return repository.AddRange(entities);
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void RemoveRange(IEnumerable<Article> entities)
        {
            repository.RemoveRange(entities);
        }

        public IArticle Update(Article entity)
        {
            return repository.Update(entity);
        }
    }
}
