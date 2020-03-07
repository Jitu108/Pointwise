using Pointwise.API.Admin.Models;
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
    [RoutePrefix("api/Articles")]
    public class ArticlesController : ApiController
    {
        private readonly IArticleService articleService;
        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService ?? throw new ArgumentNullException(nameof(articleService));
        }

        // GET: api/Articles
        [HttpGet]
        public IEnumerable<ArticleDTO> Get()
        {
            return articleService.GetAllArticles().Select(x => ArticleDTO.ToDTO((Article)x));
        }

        public IEnumerable<ArticleDTO> GetArticlesByAuthor(string author)
        {
            return articleService.GetArticlesByAuthor(author).Select(x => ArticleDTO.ToDTO((Article)x));
        }

        public IEnumerable<ArticleDTO> GetArticleByTitle(string titleString)
        {
            return articleService.GetArticleByTitle(titleString).Select(x => ArticleDTO.ToDTO((Article)x));
        }

        public IEnumerable<ArticleDTO> GetArticleByDescription(string descString)
        {
            return articleService.GetArticleByDescription(descString).Select(x => ArticleDTO.ToDTO((Article)x));
        }

        public IEnumerable<ArticleDTO> GetArticleByContent(string contentString)
        {
            return articleService.GetArticleByContent(contentString).Select(x => ArticleDTO.ToDTO((Article)x));
        }

        public IEnumerable<ArticleDTO> GetArticleBySource(int sourceId)
        {
            return articleService.GetArticleBySource(sourceId).Select(x => ArticleDTO.ToDTO((Article)x));
        }

        public IEnumerable<ArticleDTO> GetArticleByCategory(int categoryId)
        {
            return articleService.GetArticleByCategory(categoryId).Select(x => ArticleDTO.ToDTO((Article)x));
        }

        public IEnumerable<ArticleDTO> GetArticleByAssetType(ArticleAssociatedAssetType AssetType)
        {
            return articleService.GetArticleByAssetType(AssetType).Select(x => ArticleDTO.ToDTO((Article)x));
        }

        // GET: api/Articles/5
        public ArticleDTO Get(int id)
        {
            return ArticleDTO.ToDTO((Article)articleService.GetById(id));
        }

        // POST: api/Articles
        [HttpPost]
        public ArticleDTO Post([FromBody]ArticleDTO article)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var domainArticle = ArticleDTO.ToModel(article);
            var addedArticle = articleService.Add(domainArticle);

            return ArticleDTO.ToDTO((Article)addedArticle);
        }

        // PUT: api/Articles/5
        [HttpPut]
        public ArticleDTO Put(int id, [FromBody]ArticleDTO article)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (article == null) throw new ArgumentNullException(nameof(article));
            
            var domainArticle = ArticleDTO.ToModel(article);
            domainArticle.Id = id;
            var updatedArticle = articleService.Update(domainArticle);
            return ArticleDTO.ToDTO((Article)updatedArticle);
        }

        // DELETE: api/Articles/5
        [HttpDelete]
        public void Delete(int id)
        {
            articleService.Delete(id);
        }

        [HttpDelete]
        public void Delete([FromBody]IEnumerable<ArticleDTO> articles)
        {
            articleService.DeleteRange(articles.Select(x => ArticleDTO.ToModel(x)));
        }

        [HttpDelete]
        [Route("SoftDelete")]
        public void SoftDelete(int id)
        {
            articleService.SoftDelete(id);
        }

        [HttpDelete]
        [Route("UndoSoftDelete")]
        public void UndoSoftDelete(int id)
        {
            articleService.UndoSoftDelete(id);
        }

        [HttpDelete]
        [Route("SoftDeleteRange")]
        public void SoftDelete([FromBody]IEnumerable<ArticleDTO> articles)
        {
            articleService.SoftDeleteRange(articles.Select(x => ArticleDTO.ToModel(x)));
        }
    }
}
