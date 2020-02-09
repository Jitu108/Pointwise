using System;
using System.Collections.Generic;
using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;

namespace Pointwise.Domain.ServiceInterfaces
{
    public interface ISourceService
    {
        IEnumerable<ISource> GetSources();
        ISource GetById(int id);
        ISource Add(Models.Source entity);

        IEnumerable<ISource> AddRange(IEnumerable<Models.Source> entities);

        void Remove(int id);

        void RemoveRange(IEnumerable<Models.Source> entities);

        ISource Update(Models.Source entity);
    }
}
