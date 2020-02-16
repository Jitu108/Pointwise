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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categories/5
        public void Delete(int id)
        {
        }
    }
}
