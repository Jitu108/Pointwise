using Pointwise.Domain.Interfaces;
using System.Collections.Generic;

namespace Pointwise.Domain.ServiceInterfaces
{
    public interface IUserTypeService
    {
        IEnumerable<IUserType> GetUserTypes();
        IUserType GetById(int id);

        IUserType Add(Models.UserType entity);

        IEnumerable<IUserType> AddRange(IEnumerable<Models.UserType> entities);

        void Delete(int id);

        void DeleteRange(IEnumerable<Models.UserType> entities);
        void SoftDelete(int id);
        void UndoSoftDelete(int id);

        void SoftDeleteRange(IEnumerable<Models.UserType> entities);

        IUserType Update(Models.UserType entity);
    }
}
