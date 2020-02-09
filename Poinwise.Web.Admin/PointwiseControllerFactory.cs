using Pointwise.Domain.Repositories;
using Pointwise.Web.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace Poinwise.Web.Admin
{
    public class PointwiseControllerFactory : DefaultControllerFactory
    {
        // Controller Map
        private readonly Dictionary<string, Func<RequestContext, IController>> controllerMap;

        public PointwiseControllerFactory(
            IArticleRepository articleRepository, 
            ISourceRepository sourceRepository, 
            ICategoryRepository categoryRepository)
        {
            if (articleRepository == null) throw new ArgumentNullException(nameof(articleRepository));
            if (sourceRepository == null) throw new ArgumentNullException(nameof(sourceRepository));
            if (categoryRepository == null) throw new ArgumentNullException(nameof(categoryRepository));

            this.controllerMap = new Dictionary<string, Func<RequestContext, IController>>
            {
                ["Home"] = ctx => new HomeController(),
                ["Source"] = ctx => new SourceController(sourceRepository),
                ["Category"] = ctx => new CategoryController(categoryRepository)
            };
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            return this.controllerMap[controllerName](requestContext);
        }

        public override void ReleaseController(IController controller)
        {
            //base.ReleaseController(controller);
        }

    }
}