using System;
using System.Collections.Generic;
using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;

namespace Pointwise.Domain.ServiceInterfaces
{
    public interface ISourceService
    {
        IEnumerable<ISource> GetSources();
        IEnumerable<ISource> GetSourcesAll();
        IEnumerable<ISource> GetBySearchString(string searchString);
        ISource GetById(int id);
        ISource Add(Models.Source entity);

        IEnumerable<ISource> AddRange(IEnumerable<Models.Source> entities);

        bool Delete(int id);

        bool DeleteRange(IEnumerable<Models.Source> entities);
        bool SoftDelete(int id);
        bool UndoSoftDelete(int id);
        bool SoftDeleteRange(IEnumerable<Models.Source> entities);

        ISource Update(Models.Source entity);
    }
}
