using Pointwise.Domain.Models;
using Pointwise.Domain.Repositories;
using Pointwise.Domain.Services;
using Pointwise.Web.Admin.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using Pointwise.Web.Admin.ModelExtensions;

namespace Pointwise.Web.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository repository;

        public CategoryController(ICategoryRepository sourceRepository)
        {
            this.repository = sourceRepository ?? throw new ArgumentNullException(nameof(sourceRepository));
        }
        // GET: Source
        public ActionResult Index()
        {
            var service = new CategoryService(repository);
            var categories = service.GetCategories().ToList();
            var vmSources = categories
                .Select(x => (Category)x) // Cast inteface to Entity
                .Select(x => x.ToViewModel()) // Cast Entity to ViewModel
                .ToList();

            return View(vmSources);
        }

        public ActionResult New()
        {
            return View("CategoryForm", new CategoryViewModel());
        }

        public ActionResult Save(CategoryViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return View("CategoryForm", viewModel);
            }

            var service = new CategoryService(repository);

            if (viewModel.Id == 0)
            {
                service.Add(viewModel.ToDomainEntity());
            }
            else
            {
                service.Update(viewModel.ToDomainEntity());
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = new CategoryService(repository);
            var domainModel = (Category)service.GetById(id);
            var viewModel = domainModel.ToViewModel();

            return View("CategoryForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var service = new CategoryService(repository);
            service.Remove(id);

            return View("Index");
        }
    }
}