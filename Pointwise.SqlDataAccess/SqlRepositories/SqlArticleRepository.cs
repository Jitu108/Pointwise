using System;
using System.Linq;
using System.Collections.Generic;

using Pointwise.Domain.Enums;
using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Repositories;
using Pointwise.SqlDataAccess.ModelExtensions;

namespace Pointwise.SqlDataAccess.SqlRepositories
{
    public class SqlArticleRepository : IArticleRepository
    {
        private readonly PointwiseSqlContext context;

        public SqlArticleRepository(string connectionString)
        {
            context = new PointwiseSqlContext(connectionString);
        }

        public IEnumerable<IArticle> GetAllArticles()
        {
            return context.Articles.AsEnumerable().Select(x => x.ToDomainEntity());
        }
        public IArticle GetById(int id)
        {
            return context.Articles.Find(id).ToDomainEntity();
        }
        public IEnumerable<IArticle> GetArticlesByAuthor(string author)
        {
            return context.Articles.AsEnumerable().Where(x => x.Author.Contains(author)).Select(x => x.ToDomainEntity());
        }
        public IEnumerable<IArticle> GetArticleByTitle(string titleString)
        {
            return context.Articles.AsEnumerable().Where(x => x.Title.Contains(titleString)).Select(x => x.ToDomainEntity());
        }
        public IEnumerable<IArticle> GetArticleByDescription(string descString)
        {
            return context.Articles.AsEnumerable().Where(x => x.Summary.Contains(descString)).Select(x => x.ToDomainEntity());
        }
        public IEnumerable<IArticle> GetArticleByContent(string contentString)
        {
            return context.Articles.AsEnumerable().Where(x => x.Content.Contains(contentString)).Select(x => x.ToDomainEntity());
        }
        public IEnumerable<IArticle> GetArticleBySource(int sourceId)
        {
            return context.Articles.Where(x => x.Source.Id == sourceId).Select(x => x.ToDomainEntity());
        }
        public IEnumerable<IArticle> GetArticleByCategory(int categoryId)
        {
            return context.Articles.Where(x => x.Category.Id == categoryId).Select(x => x.ToDomainEntity());
        }
        public IEnumerable<IArticle> GetArticleByAssetType(ArticleAssociatedAssetType assetType)
        {
            return context.Articles.Where(x => x.AssetType == assetType).Select(x => x.ToDomainEntity());
        }




        public IArticle Add(Domain.Models.Article entity)
        {
            var sEntity = entity.ToPersistentEntity();
            var insertedRow = context.Articles.Add(sEntity);
            context.SaveChanges();

            return insertedRow.ToDomainEntity();
        }

        public IEnumerable<IArticle> AddRange(IEnumerable<Domain.Models.Article> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            var insertedRows = context.Articles.AddRange(sEntities);
            context.SaveChanges();

            return insertedRows.Select(x => x.ToDomainEntity()).AsEnumerable();
        }

        public void Remove(int id)
        {
            var sEntity = context.Articles.SingleOrDefault(x => x.Id == id);
            sEntity.IsDeleted = true;
            context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Domain.Models.Article> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            //context.Articles.RemoveRange(sEntities);
            foreach(var article in sEntities)
            {
                article.IsDeleted = true;
            }
            context.SaveChanges();
        }

        public void HardRemove(int id)
        {
            var sEntity = context.Articles.SingleOrDefault(x => x.Id == id);
            context.Articles.Remove(sEntity);
            context.SaveChanges();
        }

        public void HardRemoveRange(IEnumerable<Domain.Models.Article> entities)
        {
            var sEntities = entities.Select(x => x.ToPersistentEntity()).AsEnumerable();
            context.Articles.RemoveRange(sEntities);
            context.SaveChanges();
        }

        public IArticle Update(Domain.Models.Article entity)
        {
            var sEntity = context.Articles.Find(entity.Id);
            sEntity.Author = entity.Author;
            sEntity.Title = entity.Title;
            sEntity.Summary = entity.Summary;
            sEntity.Url = entity.Url;
            sEntity.PublicationDate = entity.PublicationDate;
            sEntity.Content = entity.Content;
            sEntity.Source = entity.Source;
            sEntity.Category = entity.Category;
            sEntity.LastModifiedOn = DateTime.Now;

            context.SaveChanges();
            return sEntity.ToDomainEntity();
        }

    }
}
