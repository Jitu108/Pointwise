using System;
using System.Collections.Generic;
using System.Linq;
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
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<ICategory> GetCategories()
        {
            return repository.GetAll().Where(x => !x.IsDeleted);
        }

        public IEnumerable<ICategory> GetCategoriesAll()
        {
            return repository.GetAll();
        }

        public IEnumerable<ICategory> GetBySearchString(string searchString)
        {
            return this.GetCategories().Where(x => x.Name.Contains(searchString));
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

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void DeleteRange(IEnumerable<Category> entities)
        {
            repository.DeleteRange(entities);

        }

        public void SoftDelete(int id)
        {
            repository.SoftDelete(id);
        }

        public void UndoSoftDelete(int id)
        {
            repository.UndoSoftDelete(id);
        }

        public void SoftDeleteRange(IEnumerable<Category> entities)
        {
            repository.SoftDeleteRange(entities);
        }

        public ICategory Update(Category entity)
        {
            return repository.Update(entity);
        }
    }
}
