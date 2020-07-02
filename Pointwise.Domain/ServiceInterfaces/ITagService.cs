using Pointwise.Domain.Interfaces;
using System.Collections.Generic;

namespace Pointwise.Domain.ServiceInterfaces
{
    public interface ITagService
    {
        IEnumerable<ITag> GetTags();
        IEnumerable<ITag> GetTagsAll();
        IEnumerable<ITag> GetBySearchString(string searchString);
        ITag GetById(int id);
        IEnumerable<ITag> GetByName(IEnumerable<string> names);

        ITag Add(Models.Tag entity);

        IEnumerable<ITag> AddRange(IEnumerable<Models.Tag> entities);

        bool Delete(int id);

        bool DeleteRange(IEnumerable<Models.Tag> entities);
        bool SoftDelete(int id);
        bool UndoSoftDelete(int id);
        bool SoftDeleteRange(IEnumerable<Models.Tag> entities);

        ITag Update(Models.Tag entity);
    }
}
