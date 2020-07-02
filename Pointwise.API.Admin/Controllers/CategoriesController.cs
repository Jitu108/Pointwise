using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Pointwise.API.Admin.Controllers
{
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }
        // GET: api/Categories
        public IHttpActionResult Get()
        {
            try
            {
                var entities = categoryService.GetCategories().ToList();

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get All Categories. Including soft-deleted ones.
        /// </summary>
        /// <returns></returns>
        [Route("All")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var entities = categoryService.GetCategoriesAll().ToList();

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult GetBySearchString(string searchString)
        {
            try
            {
                var entities = categoryService.GetBySearchString(searchString).ToList();

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Categories/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = categoryService.GetById(id);

                if (entity != null) return Ok(entity);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Categories
        [HttpPost]
        public IHttpActionResult Create([FromBody]Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var addedEntity = categoryService.Add(category);
                return CreatedAtRoute("DefaultApi", new { id = addedEntity.Id }, addedEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Categories/5
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]Category category)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                if (category == null) return BadRequest(nameof(category));

                category.Id = id;

                var updatedEntity = categoryService.Update(category);

                if (updatedEntity != null) return Ok(updatedEntity);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Categories/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var status = categoryService.Delete(id);
                if (status) return Ok();
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromBody]IEnumerable<Category> categories)
        {
            try
            {
                var status = categoryService.DeleteRange(categories);
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
                var status = categoryService.SoftDelete(id);
                if (status) return Ok();
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("UndoSoftDelete")]
        public IHttpActionResult UndoSoftDelete(int id)
        {
            try
            {
                var status = categoryService.UndoSoftDelete(id);
                if (status) return Ok();
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("SoftDeleteRange")]
        public IHttpActionResult SoftDelete([FromBody]IEnumerable<Category> categories)
        {
            try
            {
                var status = categoryService.SoftDeleteRange(categories);
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
