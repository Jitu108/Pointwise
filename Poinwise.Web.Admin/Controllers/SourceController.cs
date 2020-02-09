using Pointwise.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pointwise.Domain.Services;
using Pointwise.Domain.Models;
using Pointwise.Web.Admin.ModelExtensions;
using Pointwise.Web.Admin.ViewModels;

namespace Pointwise.Web.Admin.Controllers
{
    public class SourceController : Controller
    {
        private readonly ISourceRepository repository;

        public SourceController(ISourceRepository sourceRepository)
        {
            this.repository = sourceRepository ?? throw new ArgumentNullException(nameof(sourceRepository));
        }
        // GET: Source
        public ActionResult Index()
        {
            var service = new SourceService(repository);
            var sources = service.GetSources().ToList();
            var vmSources = sources
                .Select(x => (Source)x) // Cast inteface to Entity
                .Select(x => x.ToViewModel()) // Cast Entity to ViewModel
                .ToList();

            return View(vmSources);
        }

        public ActionResult New()
        {
            return View("SourceForm", new SourceViewModel());
        }

        public ActionResult Save(SourceViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return View("SourceForm", viewModel);
            }

            var service = new SourceService(repository);

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
            var service = new SourceService(repository);
            var domainModel = (Source)service.GetById(id);
            var viewModel = domainModel.ToViewModel();

            return View("SourceForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var service = new SourceService(repository);
            service.Remove(id);

            return View("Index");
        }
    }
}