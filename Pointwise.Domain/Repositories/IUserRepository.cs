using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using System.Collections.Generic;

namespace Pointwise.Domain.Repositories
{
    public interface IUserRepository : IRepository<IUser, User>
    {
        IUser Login(string userName, string password);
        bool Logout(string userName);
    }
}
