using Pointwise.Domain.Interfaces;
using System.Collections.Generic;

namespace Pointwise.Domain.ServiceInterfaces
{
    public interface ICategoryService
    {
        IEnumerable<ICategory> GetCategories();
        IEnumerable<ICategory> GetCategoriesAll();
        IEnumerable<ICategory> GetBySearchString(string searchString);
        ICategory GetById(int id);

        ICategory Add(Models.Category entity);

        IEnumerable<ICategory> AddRange(IEnumerable<Models.Category> entities);

        bool Delete(int id);

        bool DeleteRange(IEnumerable<Models.Category> entities);

        bool SoftDelete(int id);
        bool UndoSoftDelete(int id);
        bool SoftDeleteRange(IEnumerable<Models.Category> entities);

        ICategory Update(Models.Category entity);
    }
}
