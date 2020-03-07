using Pointwise.Domain.Interfaces;

namespace Pointwise.Domain.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        IUser Login(string userName, string password);
        bool Logout(string userName);
    }
}
