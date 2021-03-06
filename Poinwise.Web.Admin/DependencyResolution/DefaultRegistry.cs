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

namespace Pointwise.Web.Admin.DependencyResolution {
    using Pointwise.Domain.Repositories;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System;
    using System.Configuration;

    public class DefaultRegistry : Registry {

        private string connectionString;

        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            //For<IExample>().Use<Example>();

            connectionString = ConfigurationManager.ConnectionStrings["PointwiseSqlContext"].ConnectionString;

            For<IArticleRepository>().Use((IArticleRepository)GetRepository("ArticleRepositoryType"));
            For<ICategoryRepository>().Use((ICategoryRepository)GetRepository("CategoryRepositoryType"));
            For<ISourceRepository>().Use((ISourceRepository)GetRepository("SourceRepositoryType"));

            

            //For<IArticleRepository>().Use<SqlArticleRepository>().Ctor<string>().Is(connectionString);
            //For<ICategoryRepository>().Use<SqlCategoryRepository>().Ctor<string>().Is(connectionString);
            //For<ISourceRepository>().Use<SqlSourceRepository>().Ctor<string>().Is(connectionString);

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