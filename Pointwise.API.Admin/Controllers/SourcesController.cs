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
    [RoutePrefix("api/Sources")]
    public class SourcesController : ApiController
    {
        private readonly ISourceService sourceService;
        public SourcesController(ISourceService sourceService)
        {
            this.sourceService = sourceService ?? throw new ArgumentNullException(nameof(sourceService));
        }

        // GET: api/Sources
        public IHttpActionResult Get()
        {
            try
            {
                var entities = sourceService.GetSources().ToList();

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
                var entities = sourceService.GetSourcesAll().ToList();

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
                var entities = sourceService.GetBySearchString(searchString).ToList();

                if (entities.Any()) return Ok(entities);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Sources/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = sourceService.GetById(id);

                if (entity != null) return Ok(entity);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Sources
        [HttpPost]
        public IHttpActionResult Create([FromBody]Source source)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var addedEntity = sourceService.Add(source);
                return CreatedAtRoute("DefaultApi", new { id = addedEntity.Id }, addedEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Sources/5
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]Source source)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                if (source == null) return BadRequest(nameof(source));

                source.Id = id;
                var updatedEntity = sourceService.Update(source);

                if (updatedEntity != null) return Ok(updatedEntity);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Sources/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var status = sourceService.Delete(id);
                if (status) return Ok();
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromBody]IEnumerable<Source> sources)
        {
            try
            {
                var status = sourceService.DeleteRange(sources);
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
                var status = sourceService.SoftDelete(id);
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
                var status = sourceService.UndoSoftDelete(id);
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
        public IHttpActionResult SoftDelete([FromBody]IEnumerable<Source> sources)
        {
            try
            {
                var status = sourceService.SoftDeleteRange(sources);
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
