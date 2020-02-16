using Pointwise.Domain.Interfaces;
using System.Collections.Generic;

namespace Pointwise.Domain.ServiceInterfaces
{
    public interface ITagService
    {
        IEnumerable<ITag> GetTags();
        ITag GetById(int id);

        ITag Add(Models.Tag entity);

        IEnumerable<ITag> AddRange(IEnumerable<Models.Tag> entities);

        void Remove(int id);

        void RemoveRange(IEnumerable<Models.Tag> entities);

        ITag Update(Models.Tag entity);
    }
}
