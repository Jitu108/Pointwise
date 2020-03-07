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
        IEnumerable<IEntity> GetAll();
        IEntity Add(TEntity entity);
        IEnumerable<IEntity> AddRange(IEnumerable<TEntity> entities);

        void Delete(int id);
        void DeleteRange(IEnumerable<TEntity> entities);

        void SoftDelete(int id);
        void UndoSoftDelete(int id);
        void SoftDeleteRange(IEnumerable<TEntity> entities);

        IEntity GetById(int id);
        //IEnumerable<IEntity> GetBySearchString(string searchString);

        IEntity Update(TEntity entity);
    }

    public interface IRepository
    {

    }
}
