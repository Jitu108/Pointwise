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
    public class TagsController : ApiController
    {
        private readonly ITagService tagService;
        public TagsController(ITagService tagService)
        {
            this.tagService = tagService ?? throw new ArgumentNullException(nameof(tagService));
        }
        // GET: api/Tags
        public IEnumerable<ITag> Get()
        {
            return tagService.GetTags().ToList();
        }

        // GET: api/Tags/5
        public ITag Get(int id)
        {
            return tagService.GetById(id);
        }

        // POST: api/Tags
        [HttpPost]
        public ITag Create([FromBody]Tag tag)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var addedTag = tagService.Add(tag);

            return addedTag;

        }

        // PUT: api/Tags/5
        public ITag Put(int id, [FromBody]Tag tag)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            tag.Id = id;
            return tagService.Update(tag);
        }

        // DELETE: api/Tags/5
        public void Delete(int id)
        {
            tagService.Remove(id);
        }
    }
}
