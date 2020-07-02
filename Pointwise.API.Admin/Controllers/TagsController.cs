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
    [RoutePrefix("api/Tags")]
    public class TagsController : ApiController
    {
        private readonly ITagService tagService;
        public TagsController(ITagService tagService)
        {
            this.tagService = tagService ?? throw new ArgumentNullException(nameof(tagService));
        }
        // GET: api/Tags
        public IHttpActionResult Get()
        {
            try
            {
                var entities = tagService.GetTags().ToList();

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("All")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var entities = tagService.GetTagsAll().ToList();

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
                var entities = tagService.GetBySearchString(searchString).ToList();

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Tags/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = tagService.GetById(id);

                if (entity != null) return Ok(entity);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Tags
        [HttpPost]
        public IHttpActionResult Create([FromBody]Tag tag)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var addedEntity = tagService.Add(tag);
                return CreatedAtRoute("DefaultApi", new { id = addedEntity.Id }, addedEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Tags/5
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]Tag tag)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                if (tag == null) return BadRequest(nameof(tag));

                tag.Id = id;
                var updatedEntity = tagService.Update(tag);

                if (updatedEntity != null) return Ok(updatedEntity);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Tags/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var status = tagService.Delete(id);
                if (status) return Ok();
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromBody]IEnumerable<Tag> tags)
        {
            try
            {
                var status = tagService.DeleteRange(tags);
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
                var status = tagService.SoftDelete(id);
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
                var status = tagService.UndoSoftDelete(id);
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
        public IHttpActionResult SoftDelete([FromBody]IEnumerable<Tag> tags)
        {
            try
            {
                var status = tagService.SoftDeleteRange(tags);
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
