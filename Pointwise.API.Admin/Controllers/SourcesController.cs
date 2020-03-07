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
        public IEnumerable<ISource> Get()
        {
            return sourceService.GetSources().ToList();
        }

        /// <summary>
        /// Get All Categories. Including soft-deleted ones.
        /// </summary>
        /// <returns></returns>
        [Route("All")]
        public IEnumerable<ISource> GetAll()
        {
            return sourceService.GetSourcesAll().ToList();
        }

        public IEnumerable<ISource> GetBySearchString(string searchString)
        {
            return sourceService.GetBySearchString(searchString).ToList();
        }

        // GET: api/Sources/5
        public ISource Get(int id)
        {
            return sourceService.GetById(id);
        }

        // POST: api/Sources
        public ISource Post([FromBody]Source source)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var addedSource = sourceService.Add(source);

            return addedSource;
        }

        // PUT: api/Sources/5
        public ISource Put(int id, [FromBody]Source source)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (source == null) throw new ArgumentNullException(nameof(source));

            source.Id = id;
            return sourceService.Update(source);
        }

        // DELETE: api/Sources/5
        [HttpDelete]
        public void Delete(int id)
        {
            sourceService.Delete(id);
        }

        [HttpDelete]
        public void Delete([FromBody]IEnumerable<Source> sources)
        {
            sourceService.DeleteRange(sources);
        }

        [HttpDelete]
        [Route("SoftDelete")]
        public void SoftDelete(int id)
        {
            sourceService.SoftDelete(id);
        }

        [HttpDelete]
        [Route("UndoSoftDelete")]
        public void UndoSoftDelete(int id)
        {
            sourceService.UndoSoftDelete(id);
        }

        [HttpDelete]
        [Route("SoftDeleteRange")]
        public void SoftDelete([FromBody]IEnumerable<Source> sources)
        {
            sourceService.SoftDeleteRange(sources);
        }
    }
}
