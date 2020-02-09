using System;
using System.Collections.Generic;
using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.Domain.Repositories;
using Pointwise.Domain.ServiceInterfaces;

namespace Pointwise.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");

            this.repository = repository;
        }

        public IEnumerable<ICategory> GetCategories()
        {
            return repository.GetCategories();
        }

        public ICategory GetById(int id)
        {
            return repository.GetById(id);
        }

        public ICategory Add(Category entity)
        {
            return repository.Add(entity);
        }

        public IEnumerable<ICategory> AddRange(IEnumerable<Category> entities)
        {
            return repository.AddRange(entities);
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void RemoveRange(IEnumerable<Category> entities)
        {
            repository.RemoveRange(entities);
        }

        public ICategory Update(Category entity)
        {
            return repository.Update(entity);
        }
    }
}
