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

        void Delete(int id);

        void DeleteRange(IEnumerable<Models.Category> entities);

        void SoftDelete(int id);
        void UndoSoftDelete(int id);
        void SoftDeleteRange(IEnumerable<Models.Category> entities);

        ICategory Update(Models.Category entity);
    }
}
