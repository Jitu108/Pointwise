using System;
using System.Collections.Generic;
using Pointwise.Domain.Interfaces;

namespace Pointwise.Domain.ServiceInterfaces
{
    public interface IUserService
    {
        IEnumerable<IUser> GetUsers();
        IUser GetById(int id);
        IEnumerable<IUser> GetUserByName(string nameString);
        IEnumerable<IUser> GetUserByEmailAddress(string emailString);
        IEnumerable<IUser> GetUserByPhoneNumber(string phoneString);
        IEnumerable<IUser> GetBlockedUsers();
        bool UserIsBlocked(IUser user);
    }
}
