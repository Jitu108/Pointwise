using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.Domain.Repositories;
using Pointwise.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pointwise.Domain.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository repository;
        public TagService(ITagRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<ITag> GetTags()
        {
            return repository.GetAll().Where(x => !x.IsDeleted);
        }

        public IEnumerable<ITag> GetTagsAll()
        {
            return repository.GetAll();
        }

        public IEnumerable<ITag> GetBySearchString(string searchString)
        {
            return this.GetTags().Where(x => x.Name.Contains(searchString));
        }

        public ITag GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<ITag> GetByName(IEnumerable<string> names)
        {
            return repository.GetByName(names);
        }

        public ITag Add(Tag entity)
        {
            return repository.Add(entity);
        }

        public IEnumerable<ITag> AddRange(IEnumerable<Tag> entities)
        {
            return repository.AddRange(entities);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void DeleteRange(IEnumerable<Tag> entities)
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

        public void SoftDeleteRange(IEnumerable<Tag> entities)
        {
            repository.SoftDeleteRange(entities);
        }

        public ITag Update(Tag entity)
        {
            return repository.Update(entity);
        }
    }
}
