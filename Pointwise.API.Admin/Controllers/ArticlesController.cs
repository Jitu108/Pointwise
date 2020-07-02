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
        public IHttpActionResult Get()
        {
            try
            {
                var entities = articleService.GetAllArticles().Select(x => ArticleDTO.ToDTO((Article)x));

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult GetArticlesByAuthor(string author)
        {
            try
            {
                var entities = articleService.GetArticlesByAuthor(author).Select(x => ArticleDTO.ToDTO((Article)x));

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult GetArticleByTitle(string titleString)
        {
            try
            {
                var entities = articleService.GetArticleByTitle(titleString).Select(x => ArticleDTO.ToDTO((Article)x));

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult GetArticleByDescription(string descString)
        {
            try
            {
                var entities = articleService.GetArticleByDescription(descString).Select(x => ArticleDTO.ToDTO((Article)x));

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult GetArticleByContent(string contentString)
        {
            try
            {
                var entities = articleService.GetArticleByContent(contentString).Select(x => ArticleDTO.ToDTO((Article)x));

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult GetArticleBySource(int sourceId)
        {
            try
            {
                var entities = articleService.GetArticleBySource(sourceId).Select(x => ArticleDTO.ToDTO((Article)x));

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult GetArticleByCategory(int categoryId)
        {
            try
            {
                var entities = articleService.GetArticleByCategory(categoryId).Select(x => ArticleDTO.ToDTO((Article)x));

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult GetArticleByAssetType(ArticleAssociatedAssetType AssetType)
        {
            try
            {
                var entities = articleService.GetArticleByAssetType(AssetType).Select(x => ArticleDTO.ToDTO((Article)x));

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Articles/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = ArticleDTO.ToDTO((Article)articleService.GetById(id));

                if (entity != null) return Ok(entity);
                else return NotFound();
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex));
            }

        }
        //public ArticleDTO Get(int id)
        //{
        //    try
        //    {
        //        var entity = ArticleDTO.ToDTO((Article)articleService.GetById(id));
        //        return entity;
        //        //if (entity != null) return Ok(entity);
        //        //else return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        //return BadRequest(ex.Message);
        //        //return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex));
        //        throw ex;
        //    }

        //}

        // POST: api/Articles
        [HttpPost]
        public IHttpActionResult Create([FromBody]ArticleDTO article)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var domainArticle = ArticleDTO.ToModel(article);
                var addedArticle = articleService.Add(domainArticle);

                var addedArticleDTO = ArticleDTO.ToDTO((Article)addedArticle);

                return CreatedAtRoute("DefaultApi", new { id = addedArticle.Id }, addedArticleDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Articles/5
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]ArticleDTO article)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                if (article == null) return BadRequest(nameof(article));

                var domainArticle = ArticleDTO.ToModel(article);
                domainArticle.Id = id;
                var updatedEntity = articleService.Update(domainArticle);

                if (updatedEntity != null) return Ok(updatedEntity);
                else return NotFound();
            } 
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Articles/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var status = articleService.Delete(id);
                if (status) return Ok();
                else return NotFound();

            } 
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromBody]IEnumerable<ArticleDTO> articles)
        {
           try
            {
                var status = articleService.DeleteRange(articles.Select(x => ArticleDTO.ToModel(x)));
                if (status) return Ok();
                else return NotFound();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("SoftDelete")]
        public IHttpActionResult SoftDelete(int id)
        {
            try
            {
                var status = articleService.SoftDelete(id);
                if (status) return Ok();
                else return NotFound();
            } 
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex));
            }
        }

        [HttpDelete]
        [Route("UndoSoftDelete")]
        public IHttpActionResult UndoSoftDelete(int id)
        {
            try
            {
                var status = articleService.UndoSoftDelete(id);
                if (status) return Ok();
                else return NotFound();
            } 
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex));
            }
        }

        [HttpDelete]
        [Route("SoftDeleteRange")]
        public IHttpActionResult SoftDelete([FromBody]IEnumerable<ArticleDTO> articles)
        {
           try
            {
                var status = articleService.SoftDeleteRange(articles.Select(x => ArticleDTO.ToModel(x)));
                if (status) return Ok();
                else return NotFound();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
