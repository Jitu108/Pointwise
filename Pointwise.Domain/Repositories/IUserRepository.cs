using Pointwise.Domain.Interfaces;
using System.Collections.Generic;

namespace Pointwise.Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<IUser> GetAllUsers();
        IUser GetUserById(int id);
        IEnumerable<IUser> GetUserByName(string nameString);
        IEnumerable<IUser> GetUserByEmailAddress(string emailString);
        IEnumerable<IUser> GetUserByPhoneNumber(string phoneString);
        IEnumerable<IUser> GetBlockedUsers();
        bool UserIsBlocked(IUser user);
    }
}
