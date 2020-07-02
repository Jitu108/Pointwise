using Pointwise.Domain.Interfaces;
using System.Collections.Generic;

namespace Pointwise.Domain.ServiceInterfaces
{
    public interface IUserRoleService
    {
        IEnumerable<IUserRole> GetUserRoles();
        IUserRole GetById(int id);

        IUserRole Add(Models.UserRole entity);

        IEnumerable<IUserRole> AddRange(IEnumerable<Models.UserRole> entities);

        bool Delete(int id);

        bool DeleteRange(IEnumerable<Models.UserRole> entities);

        bool SoftDelete(int id);
        bool UndoSoftDelete(int id);

        bool SoftDeleteRange(IEnumerable<Models.UserRole> entities);

        IUserRole Update(Models.UserRole entity);
    }
}
