using System;
using System.Collections.Generic;
using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.Domain.Repositories;
using Pointwise.Domain.ServiceInterfaces;

namespace Pointwise.Domain.Services
{
    public class SourceService : ISourceService
    {
        private readonly ISourceRepository repository;
        public SourceService(ISourceRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");

            this.repository = repository;
        }

        public IEnumerable<ISource> GetSources()
        {
            return repository.GetSources();
        }

        public ISource GetById(int id)
        {
            return repository.GetById(id);
        }

        public ISource Add(Source entity)
        {
            return repository.Add(entity);
        }

        public IEnumerable<ISource> AddRange(IEnumerable<Source> entities)
        {
            return repository.AddRange(entities);
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void RemoveRange(IEnumerable<Source> entities)
        {
            repository.RemoveRange(entities);
        }

        public ISource Update(Source entity)
        {
            return repository.Update(entity);
        }
    }
}
