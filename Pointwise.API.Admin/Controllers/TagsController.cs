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
        public IEnumerable<ITag> Get()
        {
            return tagService.GetTags().ToList();
        }

        [Route("All")]
        public IEnumerable<ITag> GetAll()
        {
            return tagService.GetTagsAll().ToList();
        }

        public IEnumerable<ITag> GetBySearchString(string searchString)
        {
            return tagService.GetBySearchString(searchString).ToList();
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
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (tag == null) throw new ArgumentNullException(nameof(tag));

            tag.Id = id;
            return tagService.Update(tag);
        }

        // DELETE: api/Tags/5
        [HttpDelete]
        public void Delete(int id)
        {
            tagService.Delete(id);
        }

        [HttpDelete]
        public void Delete([FromBody]IEnumerable<Tag> tags)
        {
            tagService.DeleteRange(tags);
        }

        [HttpDelete]
        [Route("SoftDelete")]
        public void SoftDelete(int id)
        {
            tagService.SoftDelete(id);
        }

        [HttpDelete]
        [Route("UndoSoftDelete")]
        public void UndoSoftDelete(int id)
        {
            tagService.UndoSoftDelete(id);
        }

        [HttpDelete]
        [Route("SoftDeleteRange")]
        public void SoftDelete([FromBody]IEnumerable<Tag> tags)
        {
            tagService.SoftDeleteRange(tags);
        }
    }
}
