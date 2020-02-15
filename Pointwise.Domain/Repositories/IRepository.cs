using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointwise.Domain.Repositories
{
    public interface IRepository<IEntity, TEntity> : IRepository 
        where TEntity : IEntity
    {
        IEntity Add(TEntity entity);
        IEnumerable<IEntity> AddRange(IEnumerable<TEntity> entities);

        void Remove(int id);
        void RemoveRange(IEnumerable<TEntity> entities);

        void HardRemove(int id);
        void HardRemoveRange(IEnumerable<TEntity> entities);

        IEntity GetById(int id);

        IEntity Update(TEntity entity);
    }

    public interface IRepository
    {

    }
}
