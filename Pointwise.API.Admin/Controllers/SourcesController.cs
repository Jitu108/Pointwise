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
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            source.Id = id;
            return sourceService.Update(source);
        }

        // DELETE: api/Sources/5
        public void Delete(int id)
        {
            sourceService.Remove(id);
        }
    }
}
