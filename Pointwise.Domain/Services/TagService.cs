using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.Domain.Repositories;
using Pointwise.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;

namespace Pointwise.Domain.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository repository;
        public TagService(ITagRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");

            this.repository = repository;
        }

        public IEnumerable<ITag> GetTags()
        {
            return repository.GetTags();
        }

        public ITag GetById(int id)
        {
            return repository.GetById(id);
        }

        public ITag Add(Tag entity)
        {
            return repository.Add(entity);
        }

        public IEnumerable<ITag> AddRange(IEnumerable<Tag> entities)
        {
            return repository.AddRange(entities);
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void RemoveRange(IEnumerable<Tag> entities)
        {
            repository.RemoveRange(entities);
        }

        public ITag Update(Tag entity)
        {
            return repository.Update(entity);
        }
    }
}
