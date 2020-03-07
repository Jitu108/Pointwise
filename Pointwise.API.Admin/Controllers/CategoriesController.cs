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
        public IEnumerable<ICategory> Get()
        {
            return categoryService.GetCategories().ToList();
        }

        /// <summary>
        /// Get All Categories. Including soft-deleted ones.
        /// </summary>
        /// <returns></returns>
        [Route("All")]
        public IEnumerable<ICategory> GetAll()
        {
            return categoryService.GetCategoriesAll().ToList();
        }

        public IEnumerable<ICategory> GetBySearchString(string searchString)
        {
            return categoryService.GetBySearchString(searchString).ToList();
        }

        // GET: api/Categories/5
        public ICategory Get(int id)
        {
            return categoryService.GetById(id);
        }

        // POST: api/Categories
        [HttpPost]
        public ICategory Create([FromBody]Category category)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var addedCategory = categoryService.Add(category);

            return addedCategory;

        }

        // PUT: api/Categories/5
        public ICategory Put(int id, [FromBody]Category category)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (category == null) throw new ArgumentNullException(nameof(category));

            category.Id = id;
            
            return categoryService.Update(category);
        }

        // DELETE: api/Categories/5
        [HttpDelete]
        public void Delete(int id)
        {
            categoryService.Delete(id);
        }

        [HttpDelete]
        public void Delete([FromBody]IEnumerable<Category> categories)
        {
            categoryService.DeleteRange(categories);
        }

        [HttpDelete]
        [Route("SoftDelete")]
        public void SoftDelete(int id)
        {
            categoryService.SoftDelete(id);
        }

        [HttpDelete]
        [Route("UndoSoftDelete")]
        public void UndoSoftDelete(int id)
        {
            categoryService.UndoSoftDelete(id);
        }

        [HttpDelete]
        [Route("SoftDeleteRange")]
        public void SoftDelete([FromBody]IEnumerable<Category> categories)
        {
            categoryService.SoftDeleteRange(categories);
        }
    }
}
