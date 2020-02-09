using Pointwise.Domain.Interfaces;
using System.Collections.Generic;

namespace Pointwise.Domain.ServiceInterfaces
{
    public interface ICategoryService
    {
        IEnumerable<ICategory> GetCategories();
        ICategory GetById(int id);

        ICategory Add(Models.Category entity);

        IEnumerable<ICategory> AddRange(IEnumerable<Models.Category> entities);

        void Remove(int id);

        void RemoveRange(IEnumerable<Models.Category> entities);

        ICategory Update(Models.Category entity);
    }
}
