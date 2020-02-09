using Pointwise.Domain.Repositories;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace Poinwise.Web.Admin
{
    public class CompositionRoot
    {
        private readonly IControllerFactory controllerFactory;
        private static string connectionString;

        public CompositionRoot()
        {
            this.controllerFactory = CompositionRoot.CreateControllerFactory();
        }

        public IControllerFactory ControllerFactory
        {
            get { return this.controllerFactory; }
        }

        private static IControllerFactory CreateControllerFactory()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PointwiseSqlContext"].ConnectionString;

            var articleRepository = (IArticleRepository)GetRepository("ArticleRepositoryType");
            var sourceRepository = (ISourceRepository)GetRepository("SourceRepositoryType");
            var categoryRepository = (ICategoryRepository)GetRepository("CategoryRepositoryType");

            var controllerFactory = new PointwiseControllerFactory(articleRepository, sourceRepository, categoryRepository);

            return controllerFactory;
        }

        private static IRepository GetRepository(string appConfigName)
        {
            // Get Repository Name
            string repositoryName = ConfigurationManager.AppSettings[appConfigName];

            // Get Repository Type
            var repositoryType = Type.GetType(repositoryName, true);

            var repository = (IRepository)Activator.CreateInstance(repositoryType, connectionString);

            return repository;
        }
    }
}