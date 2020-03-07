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

        void Delete(int id);

        void DeleteRange(IEnumerable<Models.UserRole> entities);

        void SoftDelete(int id);
        void UndoSoftDelete(int id);

        void SoftDeleteRange(IEnumerable<Models.UserRole> entities);

        IUserRole Update(Models.UserRole entity);
    }
}
