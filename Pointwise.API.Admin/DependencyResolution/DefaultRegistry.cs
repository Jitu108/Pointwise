// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Pointwise.API.Admin.DependencyResolution {
    using Pointwise.API.Admin.Areas.HelpPage.Controllers;
    using Pointwise.Domain.Repositories;
    using Pointwise.Domain.ServiceInterfaces;
    using Pointwise.Domain.Services;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Routing;

    public class DefaultRegistry : Registry {

        private string connectionString;

        #region Constructors and Destructors
        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.LookForRegistries();
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    //scan.AssembliesFromApplicationBaseDirectory(assembly => !assembly.FullName.StartsWith("System.Web"));
                    //scan.AddAllTypesOf<IHttpModule>();
                });
            //For<IExample>().Use<Example>();
            connectionString = ConfigurationManager.ConnectionStrings["PointwiseSqlContext"].ConnectionString;

            For<IArticleService>().Use<ArticleService>();
            For<ICategoryService>().Use<CategoryService>();
            For<ISourceService>().Use<SourceService>();
            For<ITagService>().Use<TagService>();
            For<IImageService>().Use<ImageService>();

            For<IArticleRepository>().Use((IArticleRepository)GetRepository("ArticleRepositoryType"));
            For<ICategoryRepository>().Use((ICategoryRepository)GetRepository("CategoryRepositoryType"));
            For<ISourceRepository>().Use((ISourceRepository)GetRepository("SourceRepositoryType"));
            For<ITagRepository>().Use((ITagRepository)GetRepository("TagRepositoryType"));
            For<IImageRepository>().Use((IImageRepository)GetRepository("ImageRepositoryType"));
            For<IUserRepository>().Use((IUserRepository)GetRepository("UserRepositoryType"));
            For<IUserRoleRepository>().Use((IUserRoleRepository)GetRepository("UserRoleRepositoryType"));
            For<IUserTypeRepository>().Use((IUserTypeRepository)GetRepository("UserTypeRepositoryType"));
           

            For<HelpController>().Use(ctx => new HelpController());
        }

        private IRepository GetRepository(string appConfigName)
        {
            // Get Repository Name
            string repositoryName = ConfigurationManager.AppSettings[appConfigName];

            // Get Repository Type
            var repositoryType = Type.GetType(repositoryName, true);

            var repository = (IRepository)Activator.CreateInstance(repositoryType, connectionString);

            return repository;
        }

        #endregion
    }
}
