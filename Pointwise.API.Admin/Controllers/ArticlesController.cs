using Pointwise.Domain.Enums;
using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pointwise.API.Admin.Controllers
{
    public class ArticlesController : ApiController
    {
        private readonly IArticleService articleService;
        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService ?? throw new ArgumentNullException(nameof(articleService));
        }

        // GET: api/Articles
        [HttpGet]
        public IEnumerable<IArticle> Get()
        {
            return articleService.GetAllArticles();
        }

        public IEnumerable<IArticle> GetArticlesByAuthor(string author)
        {
            return articleService.GetArticlesByAuthor(author);
        }

        public IEnumerable<IArticle> GetArticleByTitle(string titleString)
        {
            return articleService.GetArticleByTitle(titleString);
        }

        public IEnumerable<IArticle> GetArticleByDescription(string descString)
        {
            return articleService.GetArticleByDescription(descString);
        }

        public IEnumerable<IArticle> GetArticleByContent(string contentString)
        {
            return articleService.GetArticleByContent(contentString);
        }

        public IEnumerable<IArticle> GetArticleBySource(int sourceId)
        {
            return articleService.GetArticleBySource(sourceId);
        }

        public IEnumerable<IArticle> GetArticleByCategory(int categoryId)
        {
            return articleService.GetArticleByCategory(categoryId);
        }

        public IEnumerable<IArticle> GetArticleByAssetType(ArticleAssociatedAssetType AssetType)
        {
            return articleService.GetArticleByAssetType(AssetType);
        }

        // GET: api/Articles/5
        public IArticle Get(int id)
        {
            return articleService.GetById(id);
        }

        // POST: api/Articles
        [HttpPost]
        public IArticle Post([FromBody]Article article)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var addedArticle = articleService.Add(article);

            return addedArticle;
        }

        // PUT: api/Articles/5
        [HttpPut]
        public IArticle Put(int id, [FromBody]Article article)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            article.Id = id;
            return articleService.Update(article);
        }

        // DELETE: api/Articles/5
        [HttpDelete]
        public void Delete(int id)
        {
            articleService.Remove(id);
        }
    }
}
